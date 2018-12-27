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
    public partial class LoginInformationScreen : Form
    {
        private Client _client;

        public LoginInformationScreen()
        {
            InitializeComponent();
            VisibleChanged += LoginInformationScreen_VisibleChanged;
        }

        public Client Client { get => _client; set => _client = value; }

        private void LoginInformationScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                return;
            }
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
            confirmPasswordTextBox.Text = "";
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string userName = BankAppContext.Singleton.PrepareInput(userNameTextBox.Text);
            string password = BankAppContext.Singleton.PrepareInput(passwordTextBox.Text);
            string confirmPassword = BankAppContext.Singleton.PrepareInput(confirmPasswordTextBox.Text);
            if(!BankAppContext.Singleton.ValidateInput(userName, false, 100, "User Name"))
            {
                return;
            }
            if(!BankAppContext.Singleton.ValidateInput(password, false, 100, "Password"))
            {
                return;
            }
            if(!BankAppContext.Singleton.ValidateInput(confirmPassword, false, 100, "Confirm Password")) {
                return;
            }
            if(!password.Equals(confirmPassword))
            {
                BankAppContext.Singleton.DisplayOKBox("Passwords do not match", "The passwords you have entered are not the same");
                return;
            }
            byte[] hashed = ModelFacade.Singleton.PreparePassword(password);
            _client.UserName = userName;
            _client.Password = hashed;
            int newId = ModelFacade.Singleton.InsertClient(_client);
            if(newId<0)
            {
                BankAppContext.Singleton.DisplayOKBox("Cannot create new client", "Please try a different username and try again");
            } else
            {
                BankAppContext.Singleton.DisplayOKBox("New client created", "A new client has been created, with code: "+newId);
                BankAppContext.Singleton.CustomerScreen.Prepared = false;
                BankAppContext.Singleton.TransitionToCustomerScreen(this);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            BankAppContext.Singleton.TransitionToCustomerScreen(this);
        }
    }
}
