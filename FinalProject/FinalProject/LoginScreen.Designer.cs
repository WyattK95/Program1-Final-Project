namespace FinalProject
{
    partial class LoginScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            passwordLabel = new Label();
            usernameLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            loginButton = new Button();
            titleLabel = new Label();
            roundedPanel = new Panel();
            regformButton = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            roundedPanel.SuspendLayout();
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.White;
            passwordLabel.Font = new Font("Century Schoolbook", 12F);
            passwordLabel.Location = new Point(62, 169);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(78, 20);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.White;
            usernameLabel.Font = new Font("Century Schoolbook", 12F);
            usernameLabel.Location = new Point(62, 109);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(85, 20);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.None;
            usernameTextBox.ForeColor = Color.DarkSalmon;
            usernameTextBox.Location = new Point(281, 150);
            usernameTextBox.Margin = new Padding(4, 3, 4, 3);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(234, 23);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.ForeColor = Color.DarkSalmon;
            passwordTextBox.Location = new Point(281, 210);
            passwordTextBox.Margin = new Padding(4, 3, 4, 3);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(234, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.Gainsboro;
            loginButton.Font = new Font("Segoe UI", 20F);
            loginButton.ForeColor = Color.DarkSalmon;
            loginButton.Location = new Point(300, 297);
            loginButton.Margin = new Padding(4, 3, 4, 3);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(200, 50);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.White;
            titleLabel.Font = new Font("Century Schoolbook", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(29, 13);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(319, 47);
            titleLabel.TabIndex = 5;
            titleLabel.Text = "NRC Database";
            // 
            // roundedPanel
            // 
            roundedPanel.BackColor = Color.White;
            roundedPanel.Controls.Add(titleLabel);
            roundedPanel.Controls.Add(regformButton);
            roundedPanel.Controls.Add(usernameLabel);
            roundedPanel.Controls.Add(passwordLabel);
            roundedPanel.Location = new Point(219, 18);
            roundedPanel.Name = "roundedPanel";
            roundedPanel.Size = new Size(375, 374);
            roundedPanel.TabIndex = 6;
            // 
            // regformButton
            // 
            regformButton.BackColor = Color.Transparent;
            regformButton.FlatAppearance.BorderSize = 0;
            regformButton.FlatStyle = FlatStyle.Flat;
            regformButton.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            regformButton.ForeColor = Color.RoyalBlue;
            regformButton.Location = new Point(62, 236);
            regformButton.Name = "regformButton";
            regformButton.Size = new Size(234, 23);
            regformButton.TabIndex = 0;
            regformButton.Text = "Click here if you do not have an account.";
            regformButton.UseVisualStyleBackColor = false;
            regformButton.Click += regformButton_Click;
            // 
            // LoginScreen
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSalmon;
            ClientSize = new Size(799, 450);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(roundedPanel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "LoginScreen";
            Text = "Database Access Login";
            roundedPanel.ResumeLayout(false);
            roundedPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordLabel;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
        private Label titleLabel;
        private Panel roundedPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button regformButton;
    }
}
