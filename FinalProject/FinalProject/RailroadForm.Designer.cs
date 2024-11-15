namespace FinalProject
{
    partial class RailroadForm
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
            dataGridViewRailroads = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRailroads).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewRailroads
            // 
            dataGridViewRailroads.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewRailroads.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRailroads.Location = new Point(12, 12);
            dataGridViewRailroads.Name = "dataGridViewRailroads";
            dataGridViewRailroads.RowHeadersWidth = 102;
            dataGridViewRailroads.Size = new Size(1916, 1206);
            dataGridViewRailroads.TabIndex = 0;
            // 
            // RailroadForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1230);
            Controls.Add(dataGridViewRailroads);
            Name = "RailroadForm";
            Text = "RailroadForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRailroads).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewRailroads;
    }
}