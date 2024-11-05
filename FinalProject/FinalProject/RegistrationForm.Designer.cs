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
            windowPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.White;
            titleLabel.Font = new Font("Century Schoolbook", 30F);
            titleLabel.Location = new Point(91, 4);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(176, 47);
            titleLabel.TabIndex = 12;
            titleLabel.Text = "Register";
            // 
            // registerButton
            // 
            registerButton.BackColor = Color.Gainsboro;
            registerButton.Font = new Font("Segoe UI", 20F);
            registerButton.ForeColor = Color.DarkSalmon;
            registerButton.Location = new Point(299, 291);
            registerButton.Margin = new Padding(4, 3, 4, 3);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(200, 50);
            registerButton.TabIndex = 11;
            registerButton.Text = "Register";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // passwordTextBox
            // 
            passwordTextBox.ForeColor = Color.DarkSalmon;
            passwordTextBox.Location = new Point(299, 204);
            passwordTextBox.Margin = new Padding(4, 3, 4, 3);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(200, 23);
            passwordTextBox.TabIndex = 10;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Anchor = AnchorStyles.None;
            usernameTextBox.ForeColor = Color.DarkSalmon;
            usernameTextBox.Location = new Point(298, 144);
            usernameTextBox.Margin = new Padding(4, 3, 4, 3);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(200, 23);
            usernameTextBox.TabIndex = 9;
            usernameTextBox.TextChanged += usernameTextBox_TextChanged;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.BackColor = Color.White;
            usernameLabel.Font = new Font("Century Schoolbook", 12F);
            usernameLabel.Location = new Point(299, 120);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(85, 20);
            usernameLabel.TabIndex = 8;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.BackColor = Color.White;
            passwordLabel.Font = new Font("Century Schoolbook", 12F);
            passwordLabel.Location = new Point(299, 180);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(78, 20);
            passwordLabel.TabIndex = 7;
            passwordLabel.Text = "Password";
            // 
            // windowPanel
            // 
            windowPanel.BackColor = Color.White;
            windowPanel.BorderStyle = BorderStyle.FixedSingle;
            windowPanel.Controls.Add(titleLabel);
            windowPanel.Location = new Point(219, 18);
            windowPanel.Name = "windowPanel";
            windowPanel.Size = new Size(375, 374);
            windowPanel.TabIndex = 13;
            windowPanel.Paint += roundedPanel_Paint;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSalmon;
            ClientSize = new Size(799, 450);
            Controls.Add(registerButton);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(passwordLabel);
            Controls.Add(windowPanel);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            windowPanel.ResumeLayout(false);
            windowPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Button registerButton;
        private TextBox passwordTextBox;
        private TextBox usernameTextBox;
        private Label usernameLabel;
        private Label passwordLabel;
        private Panel windowPanel;
    }
}