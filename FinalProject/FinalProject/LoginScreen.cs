using System;
using System.Data;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinalProject
{
    public partial class LoginScreen : Form
    {
        private readonly string _connectionString;

        private RegistrationForm regForm;
        public LoginScreen()
        {
            InitializeComponent();

            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");
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

            byte[] storedHash;
            byte[] storedSalt;

            try
            {
                // Retrieve stored hash and salt from the database
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT PasswordHash, Salt FROM Users WHERE Username = @Username";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Username", SqlDbType.NVarChar, 50).Value = username;
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                storedHash = (byte[])reader["PasswordHash"];
                                storedSalt = (byte[])reader["Salt"];
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password.");
                                return;
                            }
                        }
                    }
                }

                // Verify the password using PasswordHelper
                if (PasswordHelper.VerifyPassword(password, storedHash, storedSalt))
                {
                    MessageBox.Show("Login successful!");
                    MainForm mainForm = new MainForm();
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
