namespace infraredCommApp
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSetup = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonQuizTotal = new System.Windows.Forms.Button();
            this.buttonGuideTotal = new System.Windows.Forms.Button();
            this.buttonFLowLineAnalysis = new System.Windows.Forms.Button();
            this.button＿MapEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            resources.ApplyResources(this.buttonExit, "buttonExit");
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonSetup
            // 
            resources.ApplyResources(this.buttonSetup, "buttonSetup");
            this.buttonSetup.Name = "buttonSetup";
            this.buttonSetup.UseVisualStyleBackColor = true;
            this.buttonSetup.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // buttonQuizTotal
            // 
            resources.ApplyResources(this.buttonQuizTotal, "buttonQuizTotal");
            this.buttonQuizTotal.Name = "buttonQuizTotal";
            this.buttonQuizTotal.UseVisualStyleBackColor = true;
            // 
            // buttonGuideTotal
            // 
            resources.ApplyResources(this.buttonGuideTotal, "buttonGuideTotal");
            this.buttonGuideTotal.Name = "buttonGuideTotal";
            this.buttonGuideTotal.UseVisualStyleBackColor = true;
            // 
            // buttonFLowLineAnalysis
            // 
            resources.ApplyResources(this.buttonFLowLineAnalysis, "buttonFLowLineAnalysis");
            this.buttonFLowLineAnalysis.Name = "buttonFLowLineAnalysis";
            this.buttonFLowLineAnalysis.UseVisualStyleBackColor = true;
            // 
            // button＿MapEdit
            // 
            resources.ApplyResources(this.button＿MapEdit, "button＿MapEdit");
            this.button＿MapEdit.Name = "button＿MapEdit";
            this.button＿MapEdit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ControlBox = false;
            this.Controls.Add(this.button＿MapEdit);
            this.Controls.Add(this.buttonFLowLineAnalysis);
            this.Controls.Add(this.buttonGuideTotal);
            this.Controls.Add(this.buttonQuizTotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSetup);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSetup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonQuizTotal;
        private System.Windows.Forms.Button buttonGuideTotal;
        private System.Windows.Forms.Button buttonFLowLineAnalysis;
        private System.Windows.Forms.Button button＿MapEdit;
    }
}

