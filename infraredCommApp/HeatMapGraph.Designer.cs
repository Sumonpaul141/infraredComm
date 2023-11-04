namespace infraredCommApp
{
    partial class HeatMapGraph
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
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtToDateTime = new System.Windows.Forms.DateTimePicker();
            this.dtFromDateTime = new System.Windows.Forms.DateTimePicker();
            this.dayHourComboBox = new System.Windows.Forms.ComboBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxAllData = new System.Windows.Forms.ListBox();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.unselectAllBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // dtToDate
            // 
            this.dtToDate.Location = new System.Drawing.Point(28, 121);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(219, 23);
            this.dtToDate.TabIndex = 1;
            // 
            // dtFromDate
            // 
            this.dtFromDate.Location = new System.Drawing.Point(28, 59);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(219, 23);
            this.dtFromDate.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "終了日";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 33);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "開始日";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtToDateTime);
            this.groupBox2.Controls.Add(this.dtFromDateTime);
            this.groupBox2.Controls.Add(this.dayHourComboBox);
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.PictureBox);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(14, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox2.Size = new System.Drawing.Size(436, 194);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "期間指定";
            // 
            // dtToDateTime
            // 
            this.dtToDateTime.Location = new System.Drawing.Point(257, 120);
            this.dtToDateTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtToDateTime.Name = "dtToDateTime";
            this.dtToDateTime.Size = new System.Drawing.Size(146, 23);
            this.dtToDateTime.TabIndex = 41;
            // 
            // dtFromDateTime
            // 
            this.dtFromDateTime.Location = new System.Drawing.Point(257, 58);
            this.dtFromDateTime.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dtFromDateTime.Name = "dtFromDateTime";
            this.dtFromDateTime.Size = new System.Drawing.Size(146, 23);
            this.dtFromDateTime.TabIndex = 40;
            // 
            // dayHourComboBox
            // 
            this.dayHourComboBox.FormattingEnabled = true;
            this.dayHourComboBox.Items.AddRange(new object[] {
            "Hour",
            "Day"});
            this.dayHourComboBox.Location = new System.Drawing.Point(126, 11);
            this.dayHourComboBox.Name = "dayHourComboBox";
            this.dayHourComboBox.Size = new System.Drawing.Size(121, 24);
            this.dayHourComboBox.TabIndex = 40;
            this.dayHourComboBox.SelectedIndexChanged += new System.EventHandler(this.DayHourComboBoxChange);
            // 
            // PictureBox
            // 
            this.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox.Location = new System.Drawing.Point(28, 133);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(24, 10);
            this.PictureBox.TabIndex = 32;
            this.PictureBox.TabStop = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(12, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.HeatMapDialogCancel);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(368, 425);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 36);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxAllData
            // 
            this.listBoxAllData.FormattingEnabled = true;
            this.listBoxAllData.ItemHeight = 12;
            this.listBoxAllData.Location = new System.Drawing.Point(12, 225);
            this.listBoxAllData.Name = "listBoxAllData";
            this.listBoxAllData.Size = new System.Drawing.Size(438, 148);
            this.listBoxAllData.TabIndex = 32;
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.selectAllBtn.Location = new System.Drawing.Point(116, 425);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(96, 36);
            this.selectAllBtn.TabIndex = 33;
            this.selectAllBtn.Text = "Select all";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            this.selectAllBtn.Click += new System.EventHandler(this.SelectAllClick);
            // 
            // unselectAllBtn
            // 
            this.unselectAllBtn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.unselectAllBtn.Location = new System.Drawing.Point(238, 425);
            this.unselectAllBtn.Name = "unselectAllBtn";
            this.unselectAllBtn.Size = new System.Drawing.Size(109, 36);
            this.unselectAllBtn.TabIndex = 34;
            this.unselectAllBtn.Text = "Unselect all";
            this.unselectAllBtn.UseVisualStyleBackColor = true;
            this.unselectAllBtn.Click += new System.EventHandler(this.UnSelectAllClick);
            // 
            // HeatMapGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 485);
            this.Controls.Add(this.unselectAllBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.listBoxAllData);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Name = "HeatMapGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HeatMapGraph";
            this.Load += new System.EventHandler(this.HeatMapGraph_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox dayHourComboBox;
        private System.Windows.Forms.DateTimePicker dtToDateTime;
        private System.Windows.Forms.DateTimePicker dtFromDateTime;
        private System.Windows.Forms.ListBox listBoxAllData;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button unselectAllBtn;
    }
}