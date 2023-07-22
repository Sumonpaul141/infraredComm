namespace infraredCommApp
{
    partial class SEXAGEInput
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
            this.labelage = new System.Windows.Forms.Label();
            this.comboBoxAge = new System.Windows.Forms.ComboBox();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPlace = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelage
            // 
            this.labelage.AutoSize = true;
            this.labelage.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labelage.Location = new System.Drawing.Point(222, 20);
            this.labelage.Name = "labelage";
            this.labelage.Size = new System.Drawing.Size(40, 16);
            this.labelage.TabIndex = 16;
            this.labelage.Text = "年齢";
            // 
            // comboBoxAge
            // 
            this.comboBoxAge.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxAge.FormattingEnabled = true;
            this.comboBoxAge.Location = new System.Drawing.Point(279, 13);
            this.comboBoxAge.Name = "comboBoxAge";
            this.comboBoxAge.Size = new System.Drawing.Size(111, 24);
            this.comboBoxAge.TabIndex = 15;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonFemale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonFemale.Location = new System.Drawing.Point(129, 18);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(42, 20);
            this.radioButtonFemale.TabIndex = 14;
            this.radioButtonFemale.Text = "女";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Checked = true;
            this.radioButtonMale.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.radioButtonMale.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioButtonMale.Location = new System.Drawing.Point(81, 18);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(42, 20);
            this.radioButtonMale.TabIndex = 13;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "男";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "性別";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(23, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "居住地域";
            // 
            // comboBoxPlace
            // 
            this.comboBoxPlace.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxPlace.FormattingEnabled = true;
            this.comboBoxPlace.Location = new System.Drawing.Point(111, 67);
            this.comboBoxPlace.Name = "comboBoxPlace";
            this.comboBoxPlace.Size = new System.Drawing.Size(111, 24);
            this.comboBoxPlace.TabIndex = 20;
            // 
            // SEXAGEInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 127);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxPlace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAge);
            this.Controls.Add(this.labelage);
            this.Controls.Add(this.radioButtonMale);
            this.Controls.Add(this.radioButtonFemale);
            this.Name = "SEXAGEInput";
            this.Text = "利用者性別と年齢情報入力";
            this.Load += new System.EventHandler(this.SEXAGEInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAge;
        private System.Windows.Forms.Label labelage;
        private System.Windows.Forms.RadioButton radioButtonFemale;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPlace;
    }
}