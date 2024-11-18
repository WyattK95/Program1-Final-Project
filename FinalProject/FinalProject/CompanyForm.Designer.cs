namespace FinalProject
{
    partial class CompanyForm
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
            dataGridViewCompanies = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompanies).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCompanies
            // 
            dataGridViewCompanies.Anchor = AnchorStyles.None;
            dataGridViewCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCompanies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCompanies.Location = new Point(11, 70);
            dataGridViewCompanies.Margin = new Padding(2);
            dataGridViewCompanies.Name = "dataGridViewCompanies";
            dataGridViewCompanies.ReadOnly = true;
            dataGridViewCompanies.RowHeadersWidth = 102;
            dataGridViewCompanies.Size = new Size(1126, 723);
            dataGridViewCompanies.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(280, 9);
            label1.Name = "label1";
            label1.Size = new Size(550, 48);
            label1.TabIndex = 1;
            label1.Text = "Companies Related to Incidents";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 805);
            label2.Name = "label2";
            label2.Size = new Size(323, 25);
            label2.TabIndex = 2;
            label2.Text = "(Click Company Name for more details)";
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1156, 846);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewCompanies);
            Margin = new Padding(2);
            Name = "CompanyForm";
            Text = "Companies";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompanies).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCompanies;
        private Label label1;
        private Label label2;
    }
}