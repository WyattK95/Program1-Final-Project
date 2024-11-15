namespace FinalProject
{
    partial class MainForm
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
            titleLabel = new Label();
            incidentLinkLabel = new LinkLabel();
            companiesLinkLabel = new LinkLabel();
            railroadLinkLabel = new LinkLabel();
            maintenanceLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Microsoft Sans Serif", 30F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(34, 47);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(605, 46);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Welcome to the NRC Database";
            // 
            // incidentLinkLabel
            // 
            incidentLinkLabel.AutoSize = true;
            incidentLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            incidentLinkLabel.Location = new Point(76, 139);
            incidentLinkLabel.Name = "incidentLinkLabel";
            incidentLinkLabel.Size = new Size(267, 32);
            incidentLinkLabel.TabIndex = 7;
            incidentLinkLabel.TabStop = true;
            incidentLinkLabel.Text = "View or Add Incidents";
            incidentLinkLabel.LinkClicked += incidentLinkLabel_LinkClicked;
            // 
            // companiesLinkLabel
            // 
            companiesLinkLabel.AutoSize = true;
            companiesLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            companiesLinkLabel.Location = new Point(394, 139);
            companiesLinkLabel.Name = "companiesLinkLabel";
            companiesLinkLabel.Size = new Size(202, 32);
            companiesLinkLabel.TabIndex = 8;
            companiesLinkLabel.TabStop = true;
            companiesLinkLabel.Text = "View Companies";
            companiesLinkLabel.LinkClicked += companiesLinkLabel_LinkClicked;
            // 
            // railroadLinkLabel
            // 
            railroadLinkLabel.AutoSize = true;
            railroadLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            railroadLinkLabel.Location = new Point(76, 221);
            railroadLinkLabel.Name = "railroadLinkLabel";
            railroadLinkLabel.Size = new Size(183, 32);
            railroadLinkLabel.TabIndex = 9;
            railroadLinkLabel.TabStop = true;
            railroadLinkLabel.Text = "View Railroads";
            railroadLinkLabel.LinkClicked += railroadLinkLabel_LinkClicked;
            // 
            // maintenanceLinkLabel
            // 
            maintenanceLinkLabel.AutoSize = true;
            maintenanceLinkLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            maintenanceLinkLabel.Location = new Point(529, 418);
            maintenanceLinkLabel.Name = "maintenanceLinkLabel";
            maintenanceLinkLabel.Size = new Size(162, 25);
            maintenanceLinkLabel.TabIndex = 10;
            maintenanceLinkLabel.TabStop = true;
            maintenanceLinkLabel.Text = "Change password";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(703, 452);
            Controls.Add(maintenanceLinkLabel);
            Controls.Add(railroadLinkLabel);
            Controls.Add(companiesLinkLabel);
            Controls.Add(incidentLinkLabel);
            Controls.Add(titleLabel);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private LinkLabel incidentLinkLabel;
        private LinkLabel companiesLinkLabel;
        private LinkLabel railroadLinkLabel;
        private LinkLabel maintenanceLinkLabel;
    }
}