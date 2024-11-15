using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainForm : Form
    {
        private IncidentForm IncidentForm;

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

        private void companiesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompanyForm CompanyForm = new CompanyForm();
            CompanyForm.ShowDialog();
        }

        private void railroadLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RailroadForm RailroadForm = new RailroadForm();
            RailroadForm.ShowDialog();
        }
    }
}
