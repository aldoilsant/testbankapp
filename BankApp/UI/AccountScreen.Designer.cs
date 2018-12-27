namespace BankApp.UI
{
    partial class AccountScreen
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
            this.accountsDataGridView = new System.Windows.Forms.DataGridView();
            this.clientLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // accountsDataGridView
            // 
            this.accountsDataGridView.AllowUserToAddRows = false;
            this.accountsDataGridView.AllowUserToDeleteRows = false;
            this.accountsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.accountsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.accountsDataGridView.Location = new System.Drawing.Point(12, 46);
            this.accountsDataGridView.Name = "accountsDataGridView";
            this.accountsDataGridView.ReadOnly = true;
            this.accountsDataGridView.Size = new System.Drawing.Size(667, 392);
            this.accountsDataGridView.TabIndex = 0;
            // 
            // clientLabel
            // 
            this.clientLabel.AutoSize = true;
            this.clientLabel.Location = new System.Drawing.Point(9, 9);
            this.clientLabel.Name = "clientLabel";
            this.clientLabel.Size = new System.Drawing.Size(123, 13);
            this.clientLabel.TabIndex = 1;
            this.clientLabel.Text = "Displaying accounts for: ";
            // 
            // AccountScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 450);
            this.Controls.Add(this.clientLabel);
            this.Controls.Add(this.accountsDataGridView);
            this.Name = "AccountScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountScreen";
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView accountsDataGridView;
        private System.Windows.Forms.Label clientLabel;
    }
}