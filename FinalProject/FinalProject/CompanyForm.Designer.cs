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
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompanies).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCompanies
            // 
            dataGridViewCompanies.Anchor = AnchorStyles.None;
            dataGridViewCompanies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCompanies.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCompanies.Location = new Point(12, 12);
            dataGridViewCompanies.Name = "dataGridViewCompanies";
            dataGridViewCompanies.ReadOnly = true;
            dataGridViewCompanies.RowHeadersWidth = 102;
            dataGridViewCompanies.Size = new Size(1915, 1206);
            dataGridViewCompanies.TabIndex = 0;
            dataGridViewCompanies.CellContentClick += dataGridViewCompanies_CellContentClick_1;
            // 
            // CompanyForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1230);
            Controls.Add(dataGridViewCompanies);
            Name = "CompanyForm";
            Text = "Companies";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCompanies).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewCompanies;
    }
}