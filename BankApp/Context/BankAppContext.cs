using BankApp.Model;
using BankApp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp.Context
{
    class BankAppContext : ApplicationContext
    {
        private static BankAppContext _instance;
        private IDictionary<string, string> _countryCodes;
        private List<string> _countryNames;
        private LoginScreen _loginScreen;
        private CustomerScreen _customerScreen;
        private LoginInformationScreen _loginInformationScreen;
        private AccountScreen _accountScreen;

        public static BankAppContext Singleton
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BankAppContext();
                }
                return _instance;
            }
        }
        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            base.OnMainFormClosed(sender, e);
            _loginScreen.Dispose();
            _customerScreen.Dispose();
            _loginInformationScreen.Dispose();
            _accountScreen.Dispose();
        }
        public BankAppContext() : base()
        {
            ModelFacade instance = ModelFacade.Singleton;
            _loginScreen = new LoginScreen();
            _customerScreen = new CustomerScreen();
            _loginInformationScreen = new LoginInformationScreen();
            _accountScreen = new AccountScreen();
            MainForm = _loginScreen;
            MainForm.Show();
            _countryCodes = ModelFacade.Singleton.ValidCountries();
            _countryNames = new List<string>(_countryCodes.Keys);
            _countryNames.Sort();
        }

        public LoginScreen LoginScreen { get => _loginScreen; }
        public CustomerScreen CustomerScreen { get => _customerScreen; }
        public IDictionary<string, string> CountryCodes { get => _countryCodes; }
        public List<string> CountryNames { get => _countryNames; }
        public LoginInformationScreen LoginInformationScreen { get => _loginInformationScreen; }
        public AccountScreen AccountScreen { get => _accountScreen; }

        public void TransitionToScreen(Form currentForm, Form nextForm)
        {
            MainForm = null;
            if(currentForm!=null)
            {
                currentForm.Hide();
            }
            nextForm.Show();
            MainForm = nextForm;
        }
        public void TransitionToCustomerScreen(Form currentForm)
        {
            TransitionToScreen(currentForm, _customerScreen);
        }
        public void TransitionToLoginScreen(Form currentForm)
        {
            TransitionToScreen(currentForm, _loginScreen);
        }
        public void TransitionToLoginInformationScreen(Form currentForm)
        {
            TransitionToScreen(currentForm, _loginInformationScreen);
        }
        public void DisplayOKBox(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }
        public bool DisplayOkCancelBox(string caption, string message)
        {
            return MessageBox.Show(message, caption, MessageBoxButtons.OKCancel) == DialogResult.OK;
        }
        public bool ValidateInput(string text, bool canBeEmpty,int maximumLength,string fieldName)
        { 
            if(!canBeEmpty && (text==null || text.Length==0))
            {
                DisplayOKBox(fieldName + " cannot be empty", "Please provide a value for " + fieldName);
                return false;
            } else if(text!=null && text.Length>maximumLength)
            {
                DisplayOKBox(fieldName + "is too long", fieldName + " can be at most " + maximumLength + " characters long");
                return false;
            }
            return true;
        }
        public void GuardFacadeStatus(ModelFacadeStatus status)
        {
            if(status==ModelFacadeStatus.InternalError) {
                ExitWithDatabaseError();
            }
        } 
        public void ExitWithDatabaseError()
        {
            DisplayOKBox("Database Connection Failed", "The program could not connect to the database. Please make sure that the attached MDF file is on the same folder as the executable. The program will exit now.");
            Application.Exit();
        }
        public string PrepareInput(string text)
        {
            string processed = text.Trim();
            if (processed.Equals(""))
            {
                return null;
            }
            else
            {
                return processed;
            }
        }
    }
}
