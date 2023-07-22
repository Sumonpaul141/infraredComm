namespace infraredCommApp
{
    partial class setupbasic
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
            this.label6 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.logRFChn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Setuplockcheckbox = new System.Windows.Forms.CheckBox();
            this.logoutputgroup = new System.Windows.Forms.GroupBox();
            this.logfolder = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.logfoldersetup = new System.Windows.Forms.Button();
            this.workfolderGroup = new System.Windows.Forms.GroupBox();
            this.workfolder = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.workfoldersetup = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ibcfolder = new System.Windows.Forms.Label();
            this.deviceIDSetup = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxDevInfoReset = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.logoutputgroup.SuspendLayout();
            this.workfolderGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(203, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "ロック解除暗証番号";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.password.Location = new System.Drawing.Point(310, 20);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(130, 19);
            this.password.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.logRFChn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.groupBox2.Location = new System.Drawing.Point(12, 242);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(196, 50);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "無線通信チャンネル設定";
            // 
            // logRFChn
            // 
            this.logRFChn.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logRFChn.Location = new System.Drawing.Point(130, 21);
            this.logRFChn.Name = "logRFChn";
            this.logRFChn.Size = new System.Drawing.Size(51, 20);
            this.logRFChn.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(10, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "ログ読みRFチャンネル";
            // 
            // Setuplockcheckbox
            // 
            this.Setuplockcheckbox.AutoSize = true;
            this.Setuplockcheckbox.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.Setuplockcheckbox.ForeColor = System.Drawing.Color.Red;
            this.Setuplockcheckbox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Setuplockcheckbox.Location = new System.Drawing.Point(24, 23);
            this.Setuplockcheckbox.Name = "Setuplockcheckbox";
            this.Setuplockcheckbox.Size = new System.Drawing.Size(130, 16);
            this.Setuplockcheckbox.TabIndex = 38;
            this.Setuplockcheckbox.Text = "設定画面のロック有効";
            this.Setuplockcheckbox.UseVisualStyleBackColor = true;
            // 
            // logoutputgroup
            // 
            this.logoutputgroup.Controls.Add(this.logfolder);
            this.logoutputgroup.Controls.Add(this.checkBox3);
            this.logoutputgroup.Controls.Add(this.logfoldersetup);
            this.logoutputgroup.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.logoutputgroup.Location = new System.Drawing.Point(13, 81);
            this.logoutputgroup.Name = "logoutputgroup";
            this.logoutputgroup.Size = new System.Drawing.Size(672, 89);
            this.logoutputgroup.TabIndex = 33;
            this.logoutputgroup.TabStop = false;
            this.logoutputgroup.Text = "ログデータ保存用フォルダー指定";
            // 
            // logfolder
            // 
            this.logfolder.AutoSize = true;
            this.logfolder.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logfolder.Location = new System.Drawing.Point(19, 32);
            this.logfolder.Name = "logfolder";
            this.logfolder.Size = new System.Drawing.Size(45, 13);
            this.logfolder.TabIndex = 10;
            this.logfolder.Text = "label1";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(502, 57);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 16);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "操作履歴データを保存する";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // logfoldersetup
            // 
            this.logfoldersetup.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.logfoldersetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.logfoldersetup.Location = new System.Drawing.Point(596, 18);
            this.logfoldersetup.Name = "logfoldersetup";
            this.logfoldersetup.Size = new System.Drawing.Size(58, 23);
            this.logfoldersetup.TabIndex = 8;
            this.logfoldersetup.Text = "参照";
            this.logfoldersetup.UseVisualStyleBackColor = true;
            this.logfoldersetup.Click += new System.EventHandler(this.logfoldersetup_Click);
            // 
            // workfolderGroup
            // 
            this.workfolderGroup.Controls.Add(this.workfolder);
            this.workfolderGroup.Controls.Add(this.groupBox1);
            this.workfolderGroup.Controls.Add(this.workfoldersetup);
            this.workfolderGroup.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.workfolderGroup.Location = new System.Drawing.Point(12, 22);
            this.workfolderGroup.Name = "workfolderGroup";
            this.workfolderGroup.Size = new System.Drawing.Size(673, 54);
            this.workfolderGroup.TabIndex = 32;
            this.workfolderGroup.TabStop = false;
            this.workfolderGroup.Text = "作業用フォルダー指定";
            // 
            // workfolder
            // 
            this.workfolder.AutoSize = true;
            this.workfolder.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.workfolder.Location = new System.Drawing.Point(20, 25);
            this.workfolder.Name = "workfolder";
            this.workfolder.Size = new System.Drawing.Size(45, 13);
            this.workfolder.TabIndex = 11;
            this.workfolder.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.groupBox1.Location = new System.Drawing.Point(1, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 54);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "作業用フォルダー指定";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.button3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button3.Location = new System.Drawing.Point(352, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "参照";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.textBox1.Location = new System.Drawing.Point(6, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 19);
            this.textBox1.TabIndex = 7;
            // 
            // workfoldersetup
            // 
            this.workfoldersetup.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.workfoldersetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.workfoldersetup.Location = new System.Drawing.Point(597, 20);
            this.workfoldersetup.Name = "workfoldersetup";
            this.workfoldersetup.Size = new System.Drawing.Size(58, 23);
            this.workfoldersetup.TabIndex = 8;
            this.workfoldersetup.Text = "参照";
            this.workfoldersetup.UseVisualStyleBackColor = true;
            this.workfoldersetup.Click += new System.EventHandler(this.workfoldersetup_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(607, 315);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 27);
            this.button2.TabIndex = 31;
            this.button2.Text = "キャンセル";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button1.Location = new System.Drawing.Point(523, 315);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 27);
            this.button1.TabIndex = 30;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ibcfolder);
            this.groupBox3.Controls.Add(this.deviceIDSetup);
            this.groupBox3.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.groupBox3.Location = new System.Drawing.Point(13, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(672, 49);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "コンテンツファイルの指定";
            // 
            // ibcfolder
            // 
            this.ibcfolder.AutoSize = true;
            this.ibcfolder.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ibcfolder.Location = new System.Drawing.Point(19, 23);
            this.ibcfolder.Name = "ibcfolder";
            this.ibcfolder.Size = new System.Drawing.Size(45, 13);
            this.ibcfolder.TabIndex = 23;
            this.ibcfolder.Text = "label1";
            // 
            // deviceIDSetup
            // 
            this.deviceIDSetup.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.deviceIDSetup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.deviceIDSetup.Location = new System.Drawing.Point(596, 18);
            this.deviceIDSetup.Name = "deviceIDSetup";
            this.deviceIDSetup.Size = new System.Drawing.Size(58, 23);
            this.deviceIDSetup.TabIndex = 22;
            this.deviceIDSetup.Text = "参照";
            this.deviceIDSetup.UseVisualStyleBackColor = true;
            this.deviceIDSetup.Click += new System.EventHandler(this.deviceIDSetup_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.password);
            this.groupBox4.Controls.Add(this.Setuplockcheckbox);
            this.groupBox4.Location = new System.Drawing.Point(225, 242);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(460, 49);
            this.groupBox4.TabIndex = 43;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "アクセス権限設定";
            // 
            // checkBoxDevInfoReset
            // 
            this.checkBoxDevInfoReset.AutoSize = true;
            this.checkBoxDevInfoReset.Location = new System.Drawing.Point(12, 23);
            this.checkBoxDevInfoReset.Name = "checkBoxDevInfoReset";
            this.checkBoxDevInfoReset.Size = new System.Drawing.Size(120, 16);
            this.checkBoxDevInfoReset.TabIndex = 44;
            this.checkBoxDevInfoReset.Text = "端末記録DBリセット";
            this.checkBoxDevInfoReset.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(329, 23);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(151, 16);
            this.checkBox1.TabIndex = 45;
            this.checkBox1.Text = "貸出中端末情報リセット";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.checkBoxDevInfoReset);
            this.groupBox5.Location = new System.Drawing.Point(12, 303);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(495, 45);
            this.groupBox5.TabIndex = 46;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "端末管理情報";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(149, 23);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(120, 16);
            this.checkBox2.TabIndex = 46;
            this.checkBox2.Text = "端末記録DBリセット";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // setupbasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 368);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logoutputgroup);
            this.Controls.Add(this.workfolderGroup);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "setupbasic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "基本設定　V1.001  UEGG37RW2011";
            this.Load += new System.EventHandler(this.setupbasic_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.logoutputgroup.ResumeLayout(false);
            this.logoutputgroup.PerformLayout();
            this.workfolderGroup.ResumeLayout(false);
            this.workfolderGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox logRFChn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Setuplockcheckbox;
        private System.Windows.Forms.GroupBox logoutputgroup;
        private System.Windows.Forms.Button logfoldersetup;
        private System.Windows.Forms.GroupBox workfolderGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button workfoldersetup;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deviceIDSetup;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxDevInfoReset;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label workfolder;
        private System.Windows.Forms.Label logfolder;
        private System.Windows.Forms.Label ibcfolder;


    }
}