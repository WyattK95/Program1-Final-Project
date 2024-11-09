namespace FinalProject
{
    partial class RegistrationForm
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
            titleLabel = new Label();
            registerButton = new Button();
            passwordTextBox = new TextBox();
            usernameTextBox = new TextBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            windowPanel = new Panel();
            confirmPasswordTextBox = new TextBox();
            confirmPasswordLabel = new Label();
            windowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.White;
            titleLabel.Font = new Font("Century Schoolbook", 30F);
            titleLabel.Location = new Point(111, 23);
            titleLabel.Margin = new Padding(6, 0, 6, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(262, 71);
            titleLabel.TabIndex = 12;
            titleLabel.Text = "Register";
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Gainsboro;
            registerButton.Font = new Font("Segoe UI", 20F);
            registerButton.ForeColor = Color.DarkSalmon;
            registerButton.Location = new Point(111, 502);
            registerButton.Margin = new Padding(6, 5, 6, 5);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(286, 83);
            registerButton.TabIndex = 11;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.ForeColor = Color.DarkSalmon;
            passwordTextBox.Location = new Point(111, 282);
            passwordTextBox.Margin = new Padding(6, 5, 6, 5);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(284, 31);
            passwordTextBox.TabIndex = 10;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.None;
            usernameTextBox.ForeColor = Color.DarkSalmon;
            usernameTextBox.Location = new Point(111, 182);
            usernameTextBox.Margin = new Padding(6, 5, 6, 5);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(284, 31);
            usernameTextBox.TabIndex = 9;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.White;
            usernameLabel.Font = new Font("Century Schoolbook", 12F);
            usernameLabel.Location = new Point(111, 143);
            usernameLabel.Margin = new Padding(6, 0, 6, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(230, 28);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Create a username:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.White;
            passwordLabel.Font = new Font("Century Schoolbook", 12F);
            passwordLabel.Location = new Point(111, 243);
            passwordLabel.Margin = new Padding(6, 0, 6, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(225, 28);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Create a password:";
            // 
            // windowPanel
            // 
            windowPanel.BackColor = Color.White;
            windowPanel.BorderStyle = BorderStyle.FixedSingle;
            windowPanel.Controls.Add(usernameTextBox);
            windowPanel.Controls.Add(confirmPasswordTextBox);
            windowPanel.Controls.Add(passwordTextBox);
            windowPanel.Controls.Add(usernameLabel);
            windowPanel.Controls.Add(confirmPasswordLabel);
            windowPanel.Controls.Add(passwordLabel);
            windowPanel.Controls.Add(registerButton);
            windowPanel.Controls.Add(titleLabel);
            windowPanel.Location = new Point(62, 14);
            windowPanel.Margin = new Padding(4, 5, 4, 5);
            windowPanel.Name = "windowPanel";
            windowPanel.Size = new Size(535, 622);
            windowPanel.TabIndex = 13;
            windowPanel.Paint += roundedPanel_Paint;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.ForeColor = Color.DarkSalmon;
            confirmPasswordTextBox.Location = new Point(111, 378);
            confirmPasswordTextBox.Margin = new Padding(6, 5, 6, 5);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.Size = new Size(284, 31);
            confirmPasswordTextBox.TabIndex = 14;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // confirmPasswordLabel
            // 
            confirmPasswordLabel.AutoSize = true;
            confirmPasswordLabel.BackColor = Color.White;
            confirmPasswordLabel.Font = new Font("Century Schoolbook", 12F);
            confirmPasswordLabel.Location = new Point(111, 340);
            confirmPasswordLabel.Margin = new Padding(6, 0, 6, 0);
            confirmPasswordLabel.Name = "confirmPasswordLabel";
            confirmPasswordLabel.Size = new Size(223, 28);
            confirmPasswordLabel.TabIndex = 13;
            confirmPasswordLabel.Text = "Confirm password:";
            // 
            // RegistrationForm
            // 
            AcceptButton = registerButton;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSalmon;
            ClientSize = new Size(663, 673);
            Controls.Add(windowPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            windowPanel.ResumeLayout(false);
            windowPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label titleLabel;
        private Button registerButton;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Panel windowPanel;
        private TextBox confirmPasswordTextBox;
        private Label confirmPasswordLabel;
    }
}