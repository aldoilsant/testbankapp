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
    public partial class AccountScreen : Form
    {
        private Client _currentClient;
        private List<Account> _accounts;
        public AccountScreen()
        {
            InitializeComponent();
            FormClosing += AccountScreen_FormClosing;
        }

        private void AccountScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        public Client CurrentClient { get => _currentClient; set => _currentClient = value; }

        public bool prepare()
        {
            if(_currentClient==null)
            {
                return false;
            }
            _accounts = ModelFacade.Singleton.AccountsForClient(_currentClient);
            if(_accounts==null)
            {
                BankAppContext.Singleton.ExitWithDatabaseError();
            }
            clientLabel.Text = "Displaying accounts for " + _currentClient.LastName + ", " + _currentClient.FirstName;
            accountsDataGridView.DataSource = new BindingSource(_accounts, null);
            accountsDataGridView.Columns["Id"].Visible = false;
            accountsDataGridView.Columns["OriginalNumber"].Visible = false;
            accountsDataGridView.Columns["OriginalDescription"].Visible = false;
            accountsDataGridView.Columns["ClientId"].Visible = false;
            accountsDataGridView.Columns["Number"].HeaderText = "Account Number";
            accountsDataGridView.Columns["Description"].HeaderText = "Account Description";
            accountsDataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            accountsDataGridView.Columns["Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            accountsDataGridView.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            return true;
        }
    }
}
