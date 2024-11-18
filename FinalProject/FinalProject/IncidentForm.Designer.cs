namespace FinalProject
{
    partial class IncidentForm
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            searchButton = new Button();
            AddButton = new Button();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 182);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1093, 615);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label1.Location = new Point(486, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(173, 48);
            label1.TabIndex = 1;
            label1.Text = "Incidents";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 130);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(234, 25);
            label2.TabIndex = 2;
            label2.Text = "Search by SEQNOS or State:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(261, 128);
            textBox1.Margin = new Padding(4, 5, 4, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(325, 31);
            textBox1.TabIndex = 3;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(611, 124);
            searchButton.Margin = new Padding(4, 5, 4, 5);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(107, 38);
            searchButton.TabIndex = 4;
            searchButton.Text = "Search";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(1001, 123);
            AddButton.Margin = new Padding(4, 5, 4, 5);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(109, 38);
            AddButton.TabIndex = 5;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(421, 814);
            label3.Name = "label3";
            label3.Size = new Size(253, 25);
            label3.TabIndex = 6;
            label3.Text = "(Click Seqnos for more details)";
            // 
            // IncidentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 848);
            Controls.Add(label3);
            Controls.Add(AddButton);
            Controls.Add(searchButton);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "IncidentForm";
            Text = "IncidentForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button searchButton;
        private Button AddButton;
        private Label label3;
    }
}