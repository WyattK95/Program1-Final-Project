namespace FinalProject
{
    partial class PasswordChange
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
            label1 = new Label();
            usernameTextBox = new TextBox();
            oldPasswordTextBox = new TextBox();
            newPasswordTextBox = new TextBox();
            changePasswordButton = new Button();
            confirmPasswordTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(73, 35);
            label1.Name = "label1";
            label1.Size = new Size(214, 32);
            label1.TabIndex = 0;
            label1.Text = "Change Password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(100, 106);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Enter Username";
            usernameTextBox.Size = new Size(220, 23);
            usernameTextBox.TabIndex = 1;
            // 
            // oldPasswordTextBox
            // 
            oldPasswordTextBox.Location = new Point(100, 145);
            oldPasswordTextBox.Name = "oldPasswordTextBox";
            oldPasswordTextBox.PasswordChar = '*';
            oldPasswordTextBox.PlaceholderText = "Enter Old Password";
            oldPasswordTextBox.Size = new Size(220, 23);
            oldPasswordTextBox.TabIndex = 2;
            oldPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Location = new Point(100, 190);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.PasswordChar = '*';
            newPasswordTextBox.PlaceholderText = "Enter New Password";
            newPasswordTextBox.Size = new Size(220, 23);
            newPasswordTextBox.TabIndex = 3;
            newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // changePasswordButton
            // 
            changePasswordButton.Location = new Point(115, 291);
            changePasswordButton.Name = "changePasswordButton";
            changePasswordButton.Size = new Size(126, 33);
            changePasswordButton.TabIndex = 4;
            changePasswordButton.Text = "Change Password";
            changePasswordButton.UseVisualStyleBackColor = true;
            changePasswordButton.Click += changePasswordButton_Click;
            // 
            // confirmPasswordTextBox
            // 
            confirmPasswordTextBox.Location = new Point(100, 235);
            confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            confirmPasswordTextBox.PasswordChar = '*';
            confirmPasswordTextBox.PlaceholderText = "Confirm New Password";
            confirmPasswordTextBox.Size = new Size(220, 23);
            confirmPasswordTextBox.TabIndex = 5;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 109);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 6;
            label2.Text = "Username:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 148);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 7;
            label3.Text = "Old Password:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 193);
            label4.Name = "label4";
            label4.Size = new Size(87, 15);
            label4.TabIndex = 8;
            label4.Text = "New Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 228);
            label5.Name = "label5";
            label5.Size = new Size(81, 30);
            label5.TabIndex = 9;
            label5.Text = "Confirm New \r\nPassword:";
            // 
            // PasswordChange
            // 
            AcceptButton = changePasswordButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(376, 336);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(confirmPasswordTextBox);
            Controls.Add(changePasswordButton);
            Controls.Add(newPasswordTextBox);
            Controls.Add(oldPasswordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(label1);
            Name = "PasswordChange";
            Text = "PasswordChange";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox usernameTextBox;
        private TextBox oldPasswordTextBox;
        private TextBox newPasswordTextBox;
        private Button changePasswordButton;
        private TextBox confirmPasswordTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}