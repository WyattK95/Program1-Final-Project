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
            string validUsername = "hi";
            string validPassword = "hi";

            string enteredUsername = usernameTextBox.Text;
            string enteredPassword = passwordTextBox.Text;

            if (enteredUsername == validUsername && enteredPassword == validPassword)
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Access Denied", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
