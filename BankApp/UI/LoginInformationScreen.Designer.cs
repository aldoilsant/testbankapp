namespace BankApp.UI
{
    partial class LoginInformationScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please input a user name and password for the new client";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(49, 47);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(66, 13);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "User Name: ";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(56, 73);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(59, 13);
            this.passwordLabel.TabIndex = 2;
            this.passwordLabel.Text = "Password: ";
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(22, 100);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(93, 13);
            this.confirmPasswordLabel.TabIndex = 3;
            this.confirmPasswordLabel.Text = "Confirm password:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(122, 44);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.userNameTextBox.TabIndex = 4;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(122, 70);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(206, 20);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(122, 96);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(206, 20);
            this.confirmPasswordTextBox.TabIndex = 6;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(122, 126);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 7;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(253, 126);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // LoginInformationScreen
            // 
            this.AcceptButton = this.createButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 178);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.confirmPasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LoginInformationScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Information";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button cancelButton;
    }
}