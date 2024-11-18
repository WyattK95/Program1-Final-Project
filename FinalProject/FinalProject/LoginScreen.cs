using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace FinalProject
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();

            passwordTextBox.UseSystemPasswordChar = true;

            this.AcceptButton = loginButton;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // Collect user input
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your username and password.");
                return;
            }

            byte[] storedHash = null;
            byte[] storedSalt = null;

            try
            {
                // Retrieve stored hash and salt from the database using DatabaseHelper
                string query = "SELECT PasswordHash, Salt FROM Users WHERE Username = @Username";

                bool userExists = false;

                DatabaseHelper.ExecuteReader(query, reader =>
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

                // Verify the password using PasswordHelper
                if (PasswordHelper.VerifyPassword(password, storedHash, storedSalt))
                {
                    // Store the current username in the Session class
                    Session.CurrentUsername = username;

                    MessageBox.Show("Login successful!");
                    MainForm mainForm = new MainForm();
                    mainForm.FormClosed += (s, args) => this.Close();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login:\n" + ex.Message);
            }
        }

        private void regformButton_Click(object sender, EventArgs e)
        {
            // Hide the login form
            this.Hide();
            RegistrationForm regForm = new RegistrationForm();
            regForm.FormClosed += (s, args) => this.Show();
            regForm.Show();
        }
    }
}
