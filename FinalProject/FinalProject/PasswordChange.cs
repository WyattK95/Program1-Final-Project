using System;
using System.Data;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class PasswordChange : Form
    {
        private readonly string _currentUsername;

        public PasswordChange(string currentUsername)
        {
            InitializeComponent();

            _currentUsername = currentUsername;

            usernameTextBox.Text = _currentUsername;
            usernameTextBox.ReadOnly = true;

            oldPasswordTextBox.UseSystemPasswordChar = true;
            newPasswordTextBox.UseSystemPasswordChar = true;
            confirmPasswordTextBox.UseSystemPasswordChar = true;

            this.AcceptButton = changePasswordButton;
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            // Use the current username
            string username = _currentUsername;
            string oldPassword = oldPasswordTextBox.Text;
            string newPassword = newPasswordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(oldPassword) ||
                string.IsNullOrEmpty(newPassword) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New passwords do not match. Please try again.");
                newPasswordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                newPasswordTextBox.Focus();
                return;
            }

            // Enforce password policies
            if (newPassword.Length < 8)
            {
                MessageBox.Show("New password must be at least 8 characters long.");
                return;
            }

            try
            {
                // Retrieve stored hash and salt using DatabaseHelper
                string selectQuery = "SELECT PasswordHash, Salt FROM Users WHERE Username = @Username";

                byte[] storedHash = null;
                byte[] storedSalt = null;
                bool userExists = false;

                DatabaseHelper.ExecuteReader(selectQuery, reader =>
                {
                    if (reader.Read())
                    {
                        storedHash = (byte[])reader["PasswordHash"];
                        storedSalt = (byte[])reader["Salt"];
                        userExists = true;
                    }
                }, command =>
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                });

                if (!userExists)
                {
                    MessageBox.Show("Invalid username or password.");
                    return;
                }

                // Verify the old password
                if (!PasswordHelper.VerifyPassword(oldPassword, storedHash, storedSalt))
                {
                    MessageBox.Show("Old password is incorrect.");
                    return;
                }

                // Generate new salt and hash for the new password
                byte[] newSalt = PasswordHelper.GenerateSalt();
                byte[] newHash = PasswordHelper.HashPassword(newPassword, newSalt);

                // Update the database with the new hash and salt using DatabaseHelper
                string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash, Salt = @Salt WHERE Username = @Username";

                DatabaseHelper.ExecuteNonQuery(updateQuery, command =>
                {
                    command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 32).Value = newHash;
                    command.Parameters.Add("@Salt", SqlDbType.VarBinary, 16).Value = newSalt;
                    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                });

                MessageBox.Show("Password changed successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred:\n" + ex.Message);
            }
        }
    }
}
