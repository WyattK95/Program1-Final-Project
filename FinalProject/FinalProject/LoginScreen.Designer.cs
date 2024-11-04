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
            SuspendLayout();
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F);
            passwordLabel.Location = new Point(294, 168);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(76, 21);
            passwordLabel.TabIndex = 0;
            passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Segoe UI", 12F);
            usernameLabel.Location = new Point(294, 106);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(81, 21);
            usernameLabel.TabIndex = 1;
            usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(294, 130);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(209, 23);
            usernameTextBox.TabIndex = 2;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(294, 192);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(209, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI", 15F);
            loginButton.Location = new Point(294, 246);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(209, 50);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // LoginScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(passwordLabel);
            Name = "LoginScreen";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label passwordLabel;
        private Label usernameLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button loginButton;
    }
}
