using System;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainForm : Form
    {
        private IncidentForm IncidentForm;
        private PasswordChange PasswordChange;

        public MainForm()
        {
            InitializeComponent();
        }

        private void incidentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            IncidentForm = new IncidentForm();
            IncidentForm.FormClosed += (s, args) => this.Show();
            IncidentForm.Show();
        }

        private void passwordLinkLabel_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Pass the current username to the PasswordChange form
            PasswordChange passwordChangeForm = new PasswordChange(Session.CurrentUsername);
            passwordChangeForm.ShowDialog();
        }

        private void companiesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompanyForm companyForm = new CompanyForm();
            companyForm.ShowDialog();
        }

        private void railroadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RailroadForm railroadForm = new RailroadForm();
            railroadForm.ShowDialog();
        }
    }
}
