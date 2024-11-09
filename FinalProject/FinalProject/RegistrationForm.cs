using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace FinalProject
{
    public partial class RegistrationForm : Form
    {
        private readonly string _connectionString;
        public RegistrationForm()
        {
            InitializeComponent();

            _connectionString = Program.Configuration.GetConnectionString("DefaultConnection");

            passwordTextBox.UseSystemPasswordChar = true;

        }

        private void roundedPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Collect user input
            string username = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
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

            // Store in the database
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Users (Username, PasswordHash, Salt) VALUES (@Username, @PasswordHash, @Salt)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar, 50).Value = username;
                        command.Parameters.Add("@PasswordHash", System.Data.SqlDbType.VarBinary, 32).Value = hash;
                        command.Parameters.Add("@Salt", System.Data.SqlDbType.VarBinary, 16).Value = salt;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!");

                this.Hide();
                LoginScreen loginForm = new LoginScreen();
                loginForm.FormClosed += (s, args) => this.Close();
                loginForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during registration:\n" + ex.Message);
            }


        }
    }
}
