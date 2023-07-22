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
            this.logoutputgroup = new System.Windows.Forms.GroupBox();
            this.logfolder = new System.Windows.Forms.Label();
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
            this.logoutputgroup.SuspendLayout();
            this.workfolderGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoutputgroup
            // 
            this.logoutputgroup.Controls.Add(this.logfolder);
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
            // setupbasic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 368);
            this.ControlBox = false;
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
            this.logoutputgroup.ResumeLayout(false);
            this.logoutputgroup.PerformLayout();
            this.workfolderGroup.ResumeLayout(false);
            this.workfolderGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.Label workfolder;
        private System.Windows.Forms.Label logfolder;
        private System.Windows.Forms.Label ibcfolder;


    }
}