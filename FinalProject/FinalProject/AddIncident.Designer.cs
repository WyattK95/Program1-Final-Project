namespace FinalProject
{
    partial class AddIncident
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
            InsertButton = new Button();
            dataTimeReceived = new DateTimePicker();
            dataTimeComplete = new DateTimePicker();
            resposibleCity = new TextBox();
            resposibleStates = new TextBox();
            resposibleZip = new TextBox();
            typeIncident = new TextBox();
            descriptionOfIncident = new RichTextBox();
            IncidentCase = new TextBox();
            InjuryCount = new NumericUpDown();
            hospitalizationCount = new NumericUpDown();
            fatalityCount = new NumericUpDown();
            clearButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            companyNameInput = new TextBox();
            railroadNameInput = new TextBox();
            ((System.ComponentModel.ISupportInitialize)InjuryCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hospitalizationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fatalityCount).BeginInit();
            SuspendLayout();
            // 
            // InsertButton
            // 
            InsertButton.Location = new Point(313, 203);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(100, 30);
            InsertButton.TabIndex = 0;
            InsertButton.Text = "Insert Record";
            InsertButton.UseVisualStyleBackColor = true;
            InsertButton.Click += InsertButton_Click_1;
            // 
            // dataTimeReceived
            // 
            dataTimeReceived.Location = new Point(12, 31);
            dataTimeReceived.Name = "dataTimeReceived";
            dataTimeReceived.Size = new Size(193, 23);
            dataTimeReceived.TabIndex = 2;
            //dataTimeReceived.ValueChanged += dataTimeReceived_ValueChanged;
            // 
            // dataTimeComplete
            // 
            dataTimeComplete.Location = new Point(219, 28);
            dataTimeComplete.Name = "dataTimeComplete";
            dataTimeComplete.Size = new Size(175, 23);
            dataTimeComplete.TabIndex = 3;
            //dataTimeComplete.ValueChanged += dataTimeComplete_ValueChanged;
            // 
            // resposibleCity
            // 
            resposibleCity.Location = new Point(408, 28);
            resposibleCity.Name = "resposibleCity";
            resposibleCity.Size = new Size(98, 23);
            resposibleCity.TabIndex = 4;
            //resposibleCity.TextChanged += resposibleCity_TextChanged;
            // 
            // resposibleStates
            // 
            resposibleStates.Location = new Point(528, 31);
            resposibleStates.Name = "resposibleStates";
            resposibleStates.Size = new Size(100, 23);
            resposibleStates.TabIndex = 5;
            //resposibleStates.TextChanged += resposibleStates_TextChanged;
            // 
            // resposibleZip
            // 
            resposibleZip.Location = new Point(657, 31);
            resposibleZip.Name = "resposibleZip";
            resposibleZip.Size = new Size(100, 23);
            resposibleZip.TabIndex = 6;
            //resposibleZip.TextChanged += resposibleZip_TextChanged;
            // 
            // typeIncident
            // 
            typeIncident.Location = new Point(147, 93);
            typeIncident.Name = "typeIncident";
            typeIncident.Size = new Size(77, 23);
            typeIncident.TabIndex = 8;
            //typeIncident.TextChanged += typeIncident_TextChanged;
            // 
            // descriptionOfIncident
            // 
            descriptionOfIncident.Location = new Point(12, 93);
            descriptionOfIncident.Name = "descriptionOfIncident";
            descriptionOfIncident.Size = new Size(114, 83);
            descriptionOfIncident.TabIndex = 9;
            descriptionOfIncident.Text = "";
            //descriptionOfIncident.TextChanged += descriptionOfIncident_TextChanged;
            // 
            // IncidentCase
            // 
            IncidentCase.Location = new Point(243, 93);
            IncidentCase.Name = "IncidentCase";
            IncidentCase.Size = new Size(100, 23);
            IncidentCase.TabIndex = 10;
            //IncidentCase.TextChanged += IncidentCase_TextChanged;
            // 
            // InjuryCount
            // 
            InjuryCount.Location = new Point(353, 93);
            InjuryCount.Name = "InjuryCount";
            InjuryCount.Size = new Size(79, 23);
            InjuryCount.TabIndex = 12;
            //InjuryCount.ValueChanged += InjuryCount_ValueChanged;
            // 
            // hospitalizationCount
            // 
            hospitalizationCount.Location = new Point(438, 93);
            hospitalizationCount.Name = "hospitalizationCount";
            hospitalizationCount.Size = new Size(122, 23);
            hospitalizationCount.TabIndex = 13;
            //hospitalizationCount.ValueChanged += hospitalizationCount_ValueChanged;
            // 
            // fatalityCount
            // 
            fatalityCount.Location = new Point(566, 94);
            fatalityCount.Name = "fatalityCount";
            fatalityCount.Size = new Size(81, 23);
            fatalityCount.TabIndex = 14;
            //fatalityCount.ValueChanged += fatalityCount_ValueChanged;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(482, 203);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(101, 30);
            clearButton.TabIndex = 18;
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 19;
            label1.Text = "Date Time Received";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(219, 9);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 20;
            label2.Text = "Date Time Complete";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(408, 9);
            label3.Name = "label3";
            label3.Size = new Size(87, 15);
            label3.TabIndex = 21;
            label3.Text = "Resposible City";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(566, 75);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 22;
            label4.Text = "Fatality Count";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(243, 75);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 24;
            label6.Text = "Incident Case";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(147, 75);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 25;
            label7.Text = "Type Incident";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 75);
            label8.Name = "label8";
            label8.Size = new Size(129, 15);
            label8.TabIndex = 26;
            label8.Text = "Description Of Incident";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(657, 9);
            label9.Name = "label9";
            label9.Size = new Size(83, 15);
            label9.TabIndex = 27;
            label9.Text = "Resposible Zip";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(528, 9);
            label10.Name = "label10";
            label10.Size = new Size(92, 15);
            label10.TabIndex = 28;
            label10.Text = "Resposible State";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(772, 75);
            label11.Name = "label11";
            label11.Size = new Size(85, 15);
            label11.TabIndex = 29;
            label11.Text = "Railroad Name";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(653, 74);
            label12.Name = "label12";
            label12.Size = new Size(94, 15);
            label12.TabIndex = 30;
            label12.Text = "Company Name";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(432, 75);
            label13.Name = "label13";
            label13.Size = new Size(122, 15);
            label13.TabIndex = 31;
            label13.Text = "Hospitalization Count";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(353, 75);
            label14.Name = "label14";
            label14.Size = new Size(73, 15);
            label14.TabIndex = 32;
            label14.Text = "Injury Count";
            // 
            // companyNameInput
            // 
            companyNameInput.Location = new Point(657, 92);
            companyNameInput.Name = "companyNameInput";
            companyNameInput.Size = new Size(100, 23);
            companyNameInput.TabIndex = 33;
            // 
            // railroadNameInput
            // 
            railroadNameInput.Location = new Point(772, 92);
            railroadNameInput.Name = "railroadNameInput";
            railroadNameInput.Size = new Size(106, 23);
            railroadNameInput.TabIndex = 34;
            // 
            // AddIncident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 450);
            Controls.Add(railroadNameInput);
            Controls.Add(companyNameInput);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(clearButton);
            Controls.Add(fatalityCount);
            Controls.Add(hospitalizationCount);
            Controls.Add(InjuryCount);
            Controls.Add(IncidentCase);
            Controls.Add(descriptionOfIncident);
            Controls.Add(typeIncident);
            Controls.Add(resposibleZip);
            Controls.Add(resposibleStates);
            Controls.Add(resposibleCity);
            Controls.Add(dataTimeComplete);
            Controls.Add(dataTimeReceived);
            Controls.Add(InsertButton);
            Name = "AddIncident";
            Text = "AddIncident";
            ((System.ComponentModel.ISupportInitialize)InjuryCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)hospitalizationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)fatalityCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InsertButton;
        private DateTimePicker dataTimeReceived;
        private DateTimePicker dataTimeComplete;
        private TextBox resposibleCity;
        private TextBox resposibleStates;
        private TextBox resposibleZip;
        private TextBox typeIncident;
        private RichTextBox descriptionOfIncident;
        private TextBox IncidentCase;
        private NumericUpDown InjuryCount;
        private NumericUpDown hospitalizationCount;
        private NumericUpDown fatalityCount;
        private Button clearButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private TextBox companyNameInput;
        private TextBox railroadNameInput;
    }
}