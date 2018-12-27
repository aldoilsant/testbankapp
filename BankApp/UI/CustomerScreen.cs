using BankApp.Context;
using BankApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp.UI
{
    public partial class CustomerScreen : Form
    {
        private bool _prepared;
        private Client _currentClient;

        public bool Prepared { get => _prepared; set => _prepared = value; }
        public Client CurrentClient { get => _currentClient; }

        public CustomerScreen()
        {
            InitializeComponent();
            VisibleChanged += CustomerScreen_VisibleChanged;
        }

        private void CustomerScreen_VisibleChanged(object sender, EventArgs e)
        {
            if(!Visible)
            {
                return;
            }
            if(!_prepared)
            {
                _prepared = true;
                RefreshClientCodes();
                PrepareCountryCodes();
                SetToClientCode(ModelFacade.Singleton.IdentifiedClient.Id);
            }
            loggedInAsLabel.Text = "Logged in as: " + ModelFacade.Singleton.IdentifiedClient.UserName;

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if(BankAppContext.Singleton.DisplayOkCancelBox("Refresh Client Codes","If you refresh the client codes, any unsaved changes will be lost. Do you want to continue?"))
            {
                RefreshClientCodes();
                SetToNoClient();
            }
        }
        private void PrepareCountryCodes()
        {
            IDictionary<string, string> countryCodes = BankAppContext.Singleton.CountryCodes;
            countryComboBox.DataSource = new BindingSource(countryCodes, null);
            countryComboBox.DisplayMember = "Key";
            countryComboBox.ValueMember = "Value";
            countryComboBox.SelectedIndex = -1;
        }
        private void RefreshClientCodes()
        {
            List<int> codes = ModelFacade.Singleton.ClientCodes();
            if(codes==null)
            {
                BankAppContext.Singleton.ExitWithDatabaseError();
            }
            Dictionary<int, string> displayDictionary = new Dictionary<int, string>();
            foreach(int code in codes)
            {
                displayDictionary.Add(code, code.ToString());
            }
            clientCodeComboBox.DataSource = new BindingSource(displayDictionary, null);
            clientCodeComboBox.DisplayMember = "Value";
            clientCodeComboBox.ValueMember = "Key";
            clientCodeComboBox.SelectedIndex = -1;
        }
        private void SetToNoClient()
        {
            BankAppContext.Singleton.AccountScreen.Hide();
            clientCodeComboBox.SelectedIndex = -1;
            userNameValueLabel.Text = "";
            firstNameTextBox.Text = "";
            lastNameTextBox.Text = "";
            countryComboBox.SelectedIndex = -1;
            regionTextBox.Text = "";
            cityTextBox.Text = "";
            addressTextBox.Text = "";
            updateButton.Enabled = false;
            accountsButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        private void SetToClient(Client client)
        {
            _currentClient = client;
            clientCodeComboBox.SelectedValue = client.Id;
            ReloadAccounts();
            userNameValueLabel.Text = client.UserName;
            firstNameTextBox.Text = client.FirstName;
            lastNameTextBox.Text = client.LastName;
            countryComboBox.SelectedValue = client.Country;
            regionTextBox.Text = client.Region;
            cityTextBox.Text = client.City;
            addressTextBox.Text = client.Address;
            updateButton.Enabled = true;
            accountsButton.Enabled = true;
            deleteButton.Enabled = true;
        }

        private int GetSelectedClientCode()
        {
            if (clientCodeComboBox.SelectedIndex < 0)
            {
                return -1;
            }
            else
            {
                return ((KeyValuePair<int, string>)clientCodeComboBox.SelectedItem).Key;
            }
        }
        private string GetSelectedCountryCode()
        {
            if(countryComboBox.SelectedIndex<0)
            {
                return null;
            } else
            {
                return ((KeyValuePair<string, string>)countryComboBox.SelectedItem).Value;
            }
        }
        private void clientCodeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int code = GetSelectedClientCode();
            if (code >= 0)
            {
                SetToClientCode(code);
            }
        }
        private bool SetToClientCode(int code)
        {
            Client selectedClient = ModelFacade.Singleton.ClientByCode(code);
            if (selectedClient == null)
            {
                BankAppContext.Singleton.ExitWithDatabaseError();
            } else if(selectedClient.Empty)
            {
                BankAppContext.Singleton.DisplayOKBox("Could not load client", "The client you have selected could not be found. The client list will be refreshed.");
                RefreshClientCodes();
                SetToNoClient();
                return false;
            }
            else
            {
                SetToClient(selectedClient);
                return true;
            }
            return false;
        }
        private void LogOut()
        {
            SetToNoClient();
            ModelFacade.Singleton.LogOut();
            _prepared = false;
            BankAppContext.Singleton.TransitionToLoginScreen(this);
        }
        private void logOutButton_Click(object sender, EventArgs e)
        {
            LogOut();  
        }
        private bool PopulateClient(Client client)
        {
            string firstName = BankAppContext.Singleton.PrepareInput(firstNameTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(firstName, false, 100, "First Name"))
            {
                return false;
            }
            string lastName = BankAppContext.Singleton.PrepareInput(lastNameTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(lastName, false, 100, "Last Name"))
            {
                return false;
            }
            string country = GetSelectedCountryCode();
            string region = BankAppContext.Singleton.PrepareInput(regionTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(region, true, 100, "Region"))
            {
                return false;
            }
            string city = BankAppContext.Singleton.PrepareInput(cityTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(city, true, 100, "City"))
            {
                return false;
            }
            string address = BankAppContext.Singleton.PrepareInput(addressTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(address, true, 1000, "Address"))
            {
                return false;
            }
            client.FirstName = firstName;
            client.LastName = lastName;
            client.Country = country;
            client.Region = region;
            client.City = city;
            client.Address = address;
            return true;
        }
        private void newButton_Click(object sender, EventArgs e)
        {
            Client clientToCreate = new Client();
            if(!PopulateClient(clientToCreate))
            {
                return;
            }
            BankAppContext.Singleton.LoginInformationScreen.Client = clientToCreate;
            BankAppContext.Singleton.TransitionToLoginInformationScreen(this);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(_currentClient==null)
            {
                BankAppContext.Singleton.DisplayOKBox("No Client Selected", "Please select a client using the client code combo box to update it");
                return;
            }
            if(!PopulateClient(_currentClient))
            {
                return;
            }
            ModelFacadeStatus status = ModelFacade.Singleton.UpdateClient(_currentClient);
            BankAppContext.Singleton.GuardFacadeStatus(status);
            if (status==ModelFacadeStatus.Failed)
            {
                BankAppContext.Singleton.DisplayOKBox("Data outdated", "This client has been modified while you were editing its information. All the information will be reloaded. No information has been saved.");
            } else
            {
                BankAppContext.Singleton.DisplayOKBox("Client updated", "The client has been successfully updated");
            }
            SetToClientCode(_currentClient.Id);
       }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(!BankAppContext.Singleton.DisplayOkCancelBox("Delete Client?","All the client information and linked accounts will be permanently deleted. Are you sure you want to continue?"))
            {
                return;
            }
            IdentifiedClient identifiedClient = ModelFacade.Singleton.IdentifiedClient;
            bool logout = false;
            if(_currentClient.UserName.Equals(identifiedClient.UserName))
            {
                if(!BankAppContext.Singleton.DisplayOkCancelBox("Deleting your client","You are deleting you as a client. If you continue, you will be logged out of the application. Press OK to continue or Cancel to stop now."))
                {
                    return;
                }
                logout = true;
            }
            ModelFacadeStatus status = ModelFacade.Singleton.DeleteClient(_currentClient);
            BankAppContext.Singleton.GuardFacadeStatus(status);
            if (status==ModelFacadeStatus.Failed)
            {
                BankAppContext.Singleton.DisplayOKBox("Could not delete client", "This client has been modified while you were editing its information. All the information will be reloaded. The client will not be deleted.");
                SetToClientCode(_currentClient.Id);
                return;
            }
            if(logout)
            {
                LogOut();
            } else
            {
                RefreshClientCodes();
                SetToNoClient();
                BankAppContext.Singleton.DisplayOKBox("Client deleted", "The client and all linked accounts have been successfully deleted");
            }
        }
        private void ReloadAccounts()
        {
            if(_currentClient==null)
            {
                return;
            }
            BankAppContext.Singleton.AccountScreen.CurrentClient = _currentClient;
            if (!BankAppContext.Singleton.AccountScreen.prepare())
            {
                BankAppContext.Singleton.DisplayOKBox("Error loading accounts", "There was an unexpected error while loading the client accounts. The application will exit now. Please contact your administrator for more information.");
                Application.Exit();
            }
        }
        private void accountsButton_Click(object sender, EventArgs e)
        {
            if (_currentClient == null)
            {
                BankAppContext.Singleton.DisplayOKBox("No Client Selected", "Please select a client using the client code combo box to view his/her accounts");
                return;
            }
            else
            {
                ReloadAccounts();
                BankAppContext.Singleton.AccountScreen.Show();
            }
        }
    }
}
