using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            passwordTextBox.UseSystemPasswordChar = true;
            confirmPasswordTextBox.UseSystemPasswordChar = true;

            this.AcceptButton = registerButton;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Collect user input
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                passwordTextBox.Focus();
                return;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return;
            }

            // Generate salt and hash the password
            byte[] salt = PasswordHelper.GenerateSalt();
            byte[] hash = PasswordHelper.HashPassword(password, salt);

            // Store in the database using DatabaseHelper
            try
            {
                string query = "INSERT INTO Users (Username, PasswordHash, Salt) VALUES (@Username, @PasswordHash, @Salt)";

                DatabaseHelper.ExecuteNonQuery(query, command =>
                {
                    command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                    command.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 32).Value = hash;
                    command.Parameters.Add("@Salt", SqlDbType.VarBinary, 16).Value = salt;
                });

                MessageBox.Show("Registration successful!");

                // Close the registration form and show the login form
                this.Hide();
                LoginScreen loginForm = new LoginScreen();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                // Handle duplicate username error
                MessageBox.Show("Username already exists. Please choose a different username.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during registration:\n" + ex.Message);
            }
        }
    }
}
