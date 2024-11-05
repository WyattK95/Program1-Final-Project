namespace FinalProject
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Hardcoded credentials
            string validUsername = "hi";
            string validPassword = "hi";

            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            //Credential authentication messages
            if (enteredUsername == validUsername && enteredPassword == validPassword)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Access Denied", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Button hover color
        private void loginButton_MouseEnter(object sender, EventArgs e)
        {
            loginButton.BackColor = Color.Black;

        }
        //Button off-hover color
        private void loginButton_MouseLeave(object sender, EventArgs e)
        {
            loginButton.BackColor = Color.Gainsboro;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
