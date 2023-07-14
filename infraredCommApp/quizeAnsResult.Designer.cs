namespace infraredCommApp
{
    partial class quizeAnsResult
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
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.todayBtn = new System.Windows.Forms.Button();
            this.allPeriodCB = new System.Windows.Forms.CheckBox();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.quizeAnsResOkBtn = new System.Windows.Forms.Button();
            this.quizeAnsResCancelBtn = new System.Windows.Forms.Button();
            this.quizAnsResBigTextBox = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.inputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Controls.Add(this.todayBtn);
            this.inputGroupBox.Controls.Add(this.allPeriodCB);
            this.inputGroupBox.Controls.Add(this.endDateTimePicker);
            this.inputGroupBox.Controls.Add(this.startDateTimePicker);
            this.inputGroupBox.Controls.Add(this.endDateLabel);
            this.inputGroupBox.Controls.Add(this.startDateLabel);
            this.inputGroupBox.Location = new System.Drawing.Point(14, 14);
            this.inputGroupBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.inputGroupBox.Size = new System.Drawing.Size(295, 270);
            this.inputGroupBox.TabIndex = 15;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "期間指定";
            // 
            // todayBtn
            // 
            this.todayBtn.Location = new System.Drawing.Point(27, 211);
            this.todayBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.todayBtn.Name = "todayBtn";
            this.todayBtn.Size = new System.Drawing.Size(150, 39);
            this.todayBtn.TabIndex = 3;
            this.todayBtn.Text = "今日";
            this.todayBtn.UseVisualStyleBackColor = true;
            this.todayBtn.Click += new System.EventHandler(this.TodayButtonClick);
            // 
            // allPeriodCB
            // 
            this.allPeriodCB.AutoSize = true;
            this.allPeriodCB.Location = new System.Drawing.Point(28, 173);
            this.allPeriodCB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.allPeriodCB.Name = "allPeriodCB";
            this.allPeriodCB.Size = new System.Drawing.Size(71, 17);
            this.allPeriodCB.TabIndex = 2;
            this.allPeriodCB.Text = "全て期間";
            this.allPeriodCB.UseVisualStyleBackColor = true;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(27, 131);
            this.endDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(241, 20);
            this.endDateTimePicker.TabIndex = 1;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(27, 64);
            this.startDateTimePicker.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(241, 20);
            this.startDateTimePicker.TabIndex = 0;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Location = new System.Drawing.Point(25, 104);
            this.endDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(43, 13);
            this.endDateLabel.TabIndex = 5;
            this.endDateLabel.Text = "終了日";
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.Location = new System.Drawing.Point(25, 36);
            this.startDateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(43, 13);
            this.startDateLabel.TabIndex = 4;
            this.startDateLabel.Text = "開始日";
            // 
            // quizeAnsResOkBtn
            // 
            this.quizeAnsResOkBtn.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.quizeAnsResOkBtn.Location = new System.Drawing.Point(165, 348);
            this.quizeAnsResOkBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.quizeAnsResOkBtn.Name = "quizeAnsResOkBtn";
            this.quizeAnsResOkBtn.Size = new System.Drawing.Size(144, 46);
            this.quizeAnsResOkBtn.TabIndex = 7;
            this.quizeAnsResOkBtn.Text = "OK";
            this.quizeAnsResOkBtn.UseVisualStyleBackColor = true;
            this.quizeAnsResOkBtn.Click += new System.EventHandler(this.QuizeAnsResOkButtonClicked);
            // 
            // quizeAnsResCancelBtn
            // 
            this.quizeAnsResCancelBtn.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.quizeAnsResCancelBtn.Location = new System.Drawing.Point(11, 348);
            this.quizeAnsResCancelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.quizeAnsResCancelBtn.Name = "quizeAnsResCancelBtn";
            this.quizeAnsResCancelBtn.Size = new System.Drawing.Size(144, 46);
            this.quizeAnsResCancelBtn.TabIndex = 8;
            this.quizeAnsResCancelBtn.Text = "Cancel";
            this.quizeAnsResCancelBtn.UseVisualStyleBackColor = true;
            this.quizeAnsResCancelBtn.Click += new System.EventHandler(this.QuizeAnsResCancelButtonClicked);
            // 
            // quizAnsResBigTextBox
            // 
            this.quizAnsResBigTextBox.Font = new System.Drawing.Font("MS Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.quizAnsResBigTextBox.Location = new System.Drawing.Point(364, 14);
            this.quizAnsResBigTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.quizAnsResBigTextBox.Multiline = true;
            this.quizAnsResBigTextBox.Name = "quizAnsResBigTextBox";
            this.quizAnsResBigTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.quizAnsResBigTextBox.Size = new System.Drawing.Size(312, 379);
            this.quizAnsResBigTextBox.TabIndex = 25;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(190, 365);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 17);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "正解率順で表示";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(188, 365);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(119, 17);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "利用回数順で表示";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(188, 365);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(109, 17);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "クイズID順で表示";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // quizeAnsResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 412);
            this.Controls.Add(this.quizeAnsResOkBtn);
            this.Controls.Add(this.quizAnsResBigTextBox);
            this.Controls.Add(this.quizeAnsResCancelBtn);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.inputGroupBox);
            this.Name = "quizeAnsResult";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "クイズ解答状況";
            this.inputGroupBox.ResumeLayout(false);
            this.inputGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Button todayBtn;
        private System.Windows.Forms.CheckBox allPeriodCB;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.Button quizeAnsResOkBtn;
        private System.Windows.Forms.Button quizeAnsResCancelBtn;
        private System.Windows.Forms.TextBox quizAnsResBigTextBox;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}