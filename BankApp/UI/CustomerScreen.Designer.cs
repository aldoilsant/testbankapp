namespace BankApp.UI
{
    partial class CustomerScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loggedInAsLabel = new System.Windows.Forms.Label();
            this.clientCodeComboBox = new System.Windows.Forms.ComboBox();
            this.clientCodeLabel = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.userNameValueLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.regionTextBox = new System.Windows.Forms.TextBox();
            this.regionLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.updateButton = new System.Windows.Forms.Button();
            this.newButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.accountsButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.logOutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // loggedInAsLabel
            // 
            this.loggedInAsLabel.Location = new System.Drawing.Point(236, 9);
            this.loggedInAsLabel.Name = "loggedInAsLabel";
            this.loggedInAsLabel.Size = new System.Drawing.Size(153, 13);
            this.loggedInAsLabel.TabIndex = 0;
            this.loggedInAsLabel.Text = "Logged In As: XXXXXXXXXXX";
            this.loggedInAsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // clientCodeComboBox
            // 
            this.clientCodeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientCodeComboBox.FormattingEnabled = true;
            this.clientCodeComboBox.Location = new System.Drawing.Point(96, 32);
            this.clientCodeComboBox.Name = "clientCodeComboBox";
            this.clientCodeComboBox.Size = new System.Drawing.Size(137, 21);
            this.clientCodeComboBox.TabIndex = 1;
            this.clientCodeComboBox.SelectionChangeCommitted += new System.EventHandler(this.clientCodeComboBox_SelectionChangeCommitted);
            // 
            // clientCodeLabel
            // 
            this.clientCodeLabel.AutoSize = true;
            this.clientCodeLabel.Location = new System.Drawing.Point(25, 35);
            this.clientCodeLabel.Name = "clientCodeLabel";
            this.clientCodeLabel.Size = new System.Drawing.Size(64, 13);
            this.clientCodeLabel.TabIndex = 2;
            this.clientCodeLabel.Text = "Client Code:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(25, 73);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(63, 13);
            this.userNameLabel.TabIndex = 3;
            this.userNameLabel.Text = "User Name:";
            // 
            // userNameValueLabel
            // 
            this.userNameValueLabel.AutoSize = true;
            this.userNameValueLabel.Location = new System.Drawing.Point(93, 73);
            this.userNameValueLabel.Name = "userNameValueLabel";
            this.userNameValueLabel.Size = new System.Drawing.Size(182, 13);
            this.userNameValueLabel.TabIndex = 4;
            this.userNameValueLabel.Text = "XXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(28, 117);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.firstNameLabel.TabIndex = 5;
            this.firstNameLabel.Text = "First Name:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(96, 114);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(137, 20);
            this.firstNameTextBox.TabIndex = 6;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(320, 114);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(137, 20);
            this.lastNameTextBox.TabIndex = 8;
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(252, 117);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.lastNameLabel.TabIndex = 7;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // regionTextBox
            // 
            this.regionTextBox.Location = new System.Drawing.Point(320, 155);
            this.regionTextBox.Name = "regionTextBox";
            this.regionTextBox.Size = new System.Drawing.Size(137, 20);
            this.regionTextBox.TabIndex = 12;
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Location = new System.Drawing.Point(252, 158);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(44, 13);
            this.regionLabel.TabIndex = 11;
            this.regionLabel.Text = "Region:";
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(28, 158);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(46, 13);
            this.countryLabel.TabIndex = 9;
            this.countryLabel.Text = "Country:";
            // 
            // countryComboBox
            // 
            this.countryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(96, 153);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(137, 21);
            this.countryComboBox.TabIndex = 14;
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(96, 196);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(137, 20);
            this.cityTextBox.TabIndex = 16;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(28, 199);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 15;
            this.cityLabel.Text = "City:";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(96, 243);
            this.addressTextBox.Multiline = true;
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(361, 54);
            this.addressTextBox.TabIndex = 17;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(28, 261);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 18;
            this.addressLabel.Text = "Address:";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(31, 320);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(93, 23);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Update Client";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // newButton
            // 
            this.newButton.Location = new System.Drawing.Point(130, 320);
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(113, 23);
            this.newButton.TabIndex = 20;
            this.newButton.Text = "Create New Client";
            this.newButton.UseVisualStyleBackColor = true;
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(249, 320);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(88, 23);
            this.deleteButton.TabIndex = 21;
            this.deleteButton.Text = "Delete Client";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // accountsButton
            // 
            this.accountsButton.Location = new System.Drawing.Point(343, 320);
            this.accountsButton.Name = "accountsButton";
            this.accountsButton.Size = new System.Drawing.Size(113, 23);
            this.accountsButton.TabIndex = 22;
            this.accountsButton.Text = "View Accounts";
            this.accountsButton.UseVisualStyleBackColor = true;
            this.accountsButton.Click += new System.EventHandler(this.accountsButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(239, 32);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 23;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(396, 3);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 24);
            this.logOutButton.TabIndex = 24;
            this.logOutButton.Text = "Log out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // CustomerScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 355);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.accountsButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.newButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.regionTextBox);
            this.Controls.Add(this.regionLabel);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.userNameValueLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.clientCodeLabel);
            this.Controls.Add(this.clientCodeComboBox);
            this.Controls.Add(this.loggedInAsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomerScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label loggedInAsLabel;
        private System.Windows.Forms.ComboBox clientCodeComboBox;
        private System.Windows.Forms.Label clientCodeLabel;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label userNameValueLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.TextBox regionTextBox;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button newButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button accountsButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button logOutButton;
    }
}