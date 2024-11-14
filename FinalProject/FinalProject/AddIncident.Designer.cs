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
            SeqnosNumber = new TextBox();
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
            railroadId = new NumericUpDown();
            companyId = new NumericUpDown();
            clearButton = new Button();
            ((System.ComponentModel.ISupportInitialize)InjuryCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hospitalizationCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fatalityCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)railroadId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)companyId).BeginInit();
            SuspendLayout();
            // 
            // InsertButton
            // 
            InsertButton.Location = new Point(280, 163);
            InsertButton.Name = "InsertButton";
            InsertButton.Size = new Size(100, 30);
            InsertButton.TabIndex = 0;
            InsertButton.Text = "InsertButton";
            InsertButton.UseVisualStyleBackColor = true;
            // 
            // SeqnosNumber
            // 
            SeqnosNumber.Location = new Point(12, 28);
            SeqnosNumber.Name = "SeqnosNumber";
            SeqnosNumber.Size = new Size(88, 23);
            SeqnosNumber.TabIndex = 1;
            SeqnosNumber.Text = "SeqnosNumber";
            // 
            // dataTimeReceived
            // 
            dataTimeReceived.Location = new Point(106, 28);
            dataTimeReceived.Name = "dataTimeReceived";
            dataTimeReceived.Size = new Size(193, 23);
            dataTimeReceived.TabIndex = 2;
            // 
            // dataTimeComplete
            // 
            dataTimeComplete.Location = new Point(305, 28);
            dataTimeComplete.Name = "dataTimeComplete";
            dataTimeComplete.Size = new Size(175, 23);
            dataTimeComplete.TabIndex = 3;
            // 
            // resposibleCity
            // 
            resposibleCity.Location = new Point(496, 28);
            resposibleCity.Name = "resposibleCity";
            resposibleCity.Size = new Size(98, 23);
            resposibleCity.TabIndex = 4;
            resposibleCity.Text = "Resposible City";
            // 
            // resposibleStates
            // 
            resposibleStates.Location = new Point(612, 28);
            resposibleStates.Name = "resposibleStates";
            resposibleStates.Size = new Size(100, 23);
            resposibleStates.TabIndex = 5;
            resposibleStates.Text = "Resposible State";
            // 
            // resposibleZip
            // 
            resposibleZip.Location = new Point(731, 28);
            resposibleZip.Name = "resposibleZip";
            resposibleZip.Size = new Size(100, 23);
            resposibleZip.TabIndex = 6;
            resposibleZip.Text = "Resposible Zip";
            // 
            // typeIncident
            // 
            typeIncident.Location = new Point(146, 93);
            typeIncident.Name = "typeIncident";
            typeIncident.Size = new Size(109, 23);
            typeIncident.TabIndex = 8;
            typeIncident.Text = "type Incident";
            // 
            // descriptionOfIncident
            // 
            descriptionOfIncident.Location = new Point(12, 93);
            descriptionOfIncident.Name = "descriptionOfIncident";
            descriptionOfIncident.Size = new Size(114, 83);
            descriptionOfIncident.TabIndex = 9;
            descriptionOfIncident.Text = "Description Of Incident";
            // 
            // IncidentCase
            // 
            IncidentCase.Location = new Point(294, 93);
            IncidentCase.Name = "IncidentCase";
            IncidentCase.Size = new Size(100, 23);
            IncidentCase.TabIndex = 10;
            IncidentCase.Text = "IncidentCase";
            // 
            // InjuryCount
            // 
            InjuryCount.Location = new Point(424, 93);
            InjuryCount.Name = "InjuryCount";
            InjuryCount.Size = new Size(39, 23);
            InjuryCount.TabIndex = 12;
            // 
            // hospitalizationCount
            // 
            hospitalizationCount.Location = new Point(482, 93);
            hospitalizationCount.Name = "hospitalizationCount";
            hospitalizationCount.Size = new Size(42, 23);
            hospitalizationCount.TabIndex = 13;
            // 
            // fatalityCount
            // 
            fatalityCount.Location = new Point(541, 93);
            fatalityCount.Name = "fatalityCount";
            fatalityCount.Size = new Size(42, 23);
            fatalityCount.TabIndex = 14;
            // 
            // railroadId
            // 
            railroadId.Location = new Point(657, 93);
            railroadId.Name = "railroadId";
            railroadId.Size = new Size(42, 23);
            railroadId.TabIndex = 16;
            // 
            // companyId
            // 
            companyId.Location = new Point(599, 93);
            companyId.Name = "companyId";
            companyId.Size = new Size(42, 23);
            companyId.TabIndex = 17;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(405, 163);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(101, 30);
            clearButton.TabIndex = 18;
            clearButton.Text = "ClearButton";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // AddIncident
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(853, 450);
            Controls.Add(clearButton);
            Controls.Add(companyId);
            Controls.Add(railroadId);
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
            Controls.Add(SeqnosNumber);
            Controls.Add(InsertButton);
            Name = "AddIncident";
            Text = "AddIncident";
            ((System.ComponentModel.ISupportInitialize)InjuryCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)hospitalizationCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)fatalityCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)railroadId).EndInit();
            ((System.ComponentModel.ISupportInitialize)companyId).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button InsertButton;
        private TextBox SeqnosNumber;
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
        private NumericUpDown railroadId;
        private NumericUpDown companyId;
        private Button clearButton;
    }
}