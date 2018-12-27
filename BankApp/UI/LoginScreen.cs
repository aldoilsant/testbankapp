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

namespace BankApp
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
            Shown += LoginScreen_Shown;
        }

        private void LoginScreen_Shown(object sender, EventArgs e)
        {
            VisibleChanged += LoginScreen_VisibleChanged;
            CheckDatabase();
        }

        private void LoginScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                return;
            }
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
            userNameTextBox.Select();
            CheckDatabase();
        }
        private void CheckDatabase()
        {
            ModelFacadeStatus status = ModelFacade.Singleton.AreUsers();
            BankAppContext.Singleton.GuardFacadeStatus(status);
            if(status==ModelFacadeStatus.Failed)
            {
                BankAppContext.Singleton.DisplayOKBox("No clients in the database", "It seems all clients have been deleted from the database. As no user can no longer log in, the application is useless at this point. Please restore the attached MDF file and try again.");
                Application.Exit();
            }
        }
        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = BankAppContext.Singleton.PrepareInput(userNameTextBox.Text);
            if (!BankAppContext.Singleton.ValidateInput(userName, false, 100, "User Name"))
            {
                return;
            }
            string password = BankAppContext.Singleton.PrepareInput(passwordTextBox.Text);
            if(!BankAppContext.Singleton.ValidateInput(password,false,100,"Password"))
            {
                return;
            }
            ModelFacadeStatus status = ModelFacade.Singleton.Login(userName, password);
            BankAppContext.Singleton.GuardFacadeStatus(status);
            if (status==ModelFacadeStatus.OK)
            {
                BankAppContext.Singleton.TransitionToCustomerScreen(this);
            } else
            {
                BankAppContext.Singleton.DisplayOKBox("Login Failed", "The username and/or password do not match any client in the system");
            }
        }
    }
}
