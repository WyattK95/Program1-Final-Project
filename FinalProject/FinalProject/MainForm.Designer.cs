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
            passwordLinkLabel = new LinkLabel();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Century Schoolbook", 30F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(49, 78);
            titleLabel.Margin = new Padding(6, 0, 6, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(974, 71);
            titleLabel.TabIndex = 6;
            titleLabel.Text = "Welcome to the NRC Database";
            // 
            // incidentLinkLabel
            // 
            incidentLinkLabel.AutoSize = true;
            incidentLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            incidentLinkLabel.Location = new Point(67, 232);
            incidentLinkLabel.Margin = new Padding(4, 0, 4, 0);
            incidentLinkLabel.Name = "incidentLinkLabel";
            incidentLinkLabel.Size = new Size(390, 48);
            incidentLinkLabel.TabIndex = 7;
            incidentLinkLabel.TabStop = true;
            incidentLinkLabel.Text = "View or Add Incidents";
            incidentLinkLabel.LinkClicked += incidentLinkLabel_LinkClicked;
            // 
            // companiesLinkLabel
            // 
            companiesLinkLabel.AutoSize = true;
            companiesLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            companiesLinkLabel.Location = new Point(67, 358);
            companiesLinkLabel.Margin = new Padding(4, 0, 4, 0);
            companiesLinkLabel.Name = "companiesLinkLabel";
            companiesLinkLabel.Size = new Size(297, 48);
            companiesLinkLabel.TabIndex = 8;
            companiesLinkLabel.TabStop = true;
            companiesLinkLabel.Text = "View Companies";
            companiesLinkLabel.LinkClicked += companiesLinkLabel_LinkClicked;
            // 
            // railroadLinkLabel
            // 
            railroadLinkLabel.AutoSize = true;
            railroadLinkLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            railroadLinkLabel.Location = new Point(67, 512);
            railroadLinkLabel.Margin = new Padding(4, 0, 4, 0);
            railroadLinkLabel.Name = "railroadLinkLabel";
            railroadLinkLabel.Size = new Size(268, 48);
            railroadLinkLabel.TabIndex = 9;
            railroadLinkLabel.TabStop = true;
            railroadLinkLabel.Text = "View Railroads";
            railroadLinkLabel.LinkClicked += railroadLinkLabel_LinkClicked;
            // 
            // passwordLinkLabel
            // 
            passwordLinkLabel.AutoSize = true;
            passwordLinkLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLinkLabel.Location = new Point(756, 697);
            passwordLinkLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLinkLabel.Name = "passwordLinkLabel";
            passwordLinkLabel.Size = new Size(243, 40);
            passwordLinkLabel.TabIndex = 10;
            passwordLinkLabel.TabStop = true;
            passwordLinkLabel.Text = "Change password";
            passwordLinkLabel.LinkClicked += passwordLinkLabel_LinkClicked_1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1029, 753);
            Controls.Add(passwordLinkLabel);
            Controls.Add(railroadLinkLabel);
            Controls.Add(companiesLinkLabel);
            Controls.Add(incidentLinkLabel);
            Controls.Add(titleLabel);
            Margin = new Padding(4, 5, 4, 5);
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
        private LinkLabel passwordLinkLabel;
    }
}