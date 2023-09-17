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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSetup = new System.Windows.Forms.Button();
            this.buttonQuizRate = new System.Windows.Forms.Button();
            this.buttonGuideTotal = new System.Windows.Forms.Button();
            this.buttonFLowLineAnalysis = new System.Windows.Forms.Button();
            this.map_button = new System.Windows.Forms.Button();
            this.set_map_label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.追加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.コンテンツToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.赤外線ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.削除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblimage = new System.Windows.Forms.Label();
            this.lblCboImageName = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblTagNameTest = new System.Windows.Forms.Label();
            this.chartWithData = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.progBarTagLoad = new System.Windows.Forms.ProgressBar();
            this.lblProgBarTagLoadPercent = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnalyzedData = new System.Windows.Forms.TextBox();
            this.rdoQuizId = new System.Windows.Forms.RadioButton();
            this.rdoAccurate = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnBarGraph = new System.Windows.Forms.Button();
            this.ControlGroupBox = new System.Windows.Forms.GroupBox();
            this.resultListView = new System.Windows.Forms.ListView();
            this.add_map_button1 = new System.Windows.Forms.Button();
            this.map_comboBox1 = new System.Windows.Forms.ComboBox();
            this.delete_map_button8 = new System.Windows.Forms.Button();
            this.Exit_map_edit_button9 = new System.Windows.Forms.Button();
            this.lblToDate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWithData)).BeginInit();
            this.ControlGroupBox.SuspendLayout();
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
            // buttonQuizRate
            // 
            resources.ApplyResources(this.buttonQuizRate, "buttonQuizRate");
            this.buttonQuizRate.Name = "buttonQuizRate";
            this.buttonQuizRate.UseVisualStyleBackColor = true;
            this.buttonQuizRate.Click += new System.EventHandler(this.buttonQuizTotal_Click);
            // 
            // buttonGuideTotal
            // 
            resources.ApplyResources(this.buttonGuideTotal, "buttonGuideTotal");
            this.buttonGuideTotal.Name = "buttonGuideTotal";
            this.buttonGuideTotal.UseVisualStyleBackColor = true;
            this.buttonGuideTotal.Click += new System.EventHandler(this.ButtonGuideClicked);
            // 
            // buttonFLowLineAnalysis
            // 
            resources.ApplyResources(this.buttonFLowLineAnalysis, "buttonFLowLineAnalysis");
            this.buttonFLowLineAnalysis.Name = "buttonFLowLineAnalysis";
            this.buttonFLowLineAnalysis.UseVisualStyleBackColor = true;
            this.buttonFLowLineAnalysis.Click += new System.EventHandler(this.buttonFLowLineAnalysis_Click);
            // 
            // map_button
            // 
            resources.ApplyResources(this.map_button, "map_button");
            this.map_button.Name = "map_button";
            this.map_button.UseVisualStyleBackColor = true;
            this.map_button.Click += new System.EventHandler(this.button＿MapEdit_Click);
            // 
            // set_map_label1
            // 
            resources.ApplyResources(this.set_map_label1, "set_map_label1");
            this.set_map_label1.Name = "set_map_label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.追加ToolStripMenuItem,
            this.削除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // 追加ToolStripMenuItem
            // 
            this.追加ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.コンテンツToolStripMenuItem,
            this.赤外線ToolStripMenuItem});
            this.追加ToolStripMenuItem.Name = "追加ToolStripMenuItem";
            resources.ApplyResources(this.追加ToolStripMenuItem, "追加ToolStripMenuItem");
            // 
            // コンテンツToolStripMenuItem
            // 
            this.コンテンツToolStripMenuItem.Name = "コンテンツToolStripMenuItem";
            resources.ApplyResources(this.コンテンツToolStripMenuItem, "コンテンツToolStripMenuItem");
            this.コンテンツToolStripMenuItem.Click += new System.EventHandler(this.コンテンツToolStripMenuItem_Click);
            // 
            // 赤外線ToolStripMenuItem
            // 
            this.赤外線ToolStripMenuItem.Name = "赤外線ToolStripMenuItem";
            resources.ApplyResources(this.赤外線ToolStripMenuItem, "赤外線ToolStripMenuItem");
            this.赤外線ToolStripMenuItem.Click += new System.EventHandler(this.赤外線ToolStripMenuItem_Click);
            // 
            // 削除ToolStripMenuItem
            // 
            this.削除ToolStripMenuItem.Name = "削除ToolStripMenuItem";
            resources.ApplyResources(this.削除ToolStripMenuItem, "削除ToolStripMenuItem");
            this.削除ToolStripMenuItem.Click += new System.EventHandler(this.削除ToolStripMenuItem_Click);
            // 
            // lblimage
            // 
            resources.ApplyResources(this.lblimage, "lblimage");
            this.lblimage.Name = "lblimage";
            // 
            // lblCboImageName
            // 
            resources.ApplyResources(this.lblCboImageName, "lblCboImageName");
            this.lblCboImageName.Name = "lblCboImageName";
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // lblTagNameTest
            // 
            resources.ApplyResources(this.lblTagNameTest, "lblTagNameTest");
            this.lblTagNameTest.Name = "lblTagNameTest";
            // 
            // chartWithData
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWithData.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWithData.Legends.Add(legend1);
            resources.ApplyResources(this.chartWithData, "chartWithData");
            this.chartWithData.Name = "chartWithData";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWithData.Series.Add(series1);
            // 
            // lblMonth
            // 
            resources.ApplyResources(this.lblMonth, "lblMonth");
            this.lblMonth.Name = "lblMonth";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDate.Name = "lblDate";
            // 
            // progBarTagLoad
            // 
            resources.ApplyResources(this.progBarTagLoad, "progBarTagLoad");
            this.progBarTagLoad.Name = "progBarTagLoad";
            // 
            // lblProgBarTagLoadPercent
            // 
            resources.ApplyResources(this.lblProgBarTagLoadPercent, "lblProgBarTagLoadPercent");
            this.lblProgBarTagLoadPercent.Name = "lblProgBarTagLoadPercent";
            // 
            // lblFromDate
            // 
            resources.ApplyResources(this.lblFromDate, "lblFromDate");
            this.lblFromDate.Name = "lblFromDate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtAnalyzedData
            // 
            resources.ApplyResources(this.txtAnalyzedData, "txtAnalyzedData");
            this.txtAnalyzedData.Name = "txtAnalyzedData";
            this.txtAnalyzedData.ReadOnly = true;
            // 
            // rdoQuizId
            // 
            resources.ApplyResources(this.rdoQuizId, "rdoQuizId");
            this.rdoQuizId.Name = "rdoQuizId";
            this.rdoQuizId.TabStop = true;
            this.rdoQuizId.UseVisualStyleBackColor = true;
            this.rdoQuizId.CheckedChanged += new System.EventHandler(this.RadioAscDescChanged);
            // 
            // rdoAccurate
            // 
            resources.ApplyResources(this.rdoAccurate, "rdoAccurate");
            this.rdoAccurate.Name = "rdoAccurate";
            this.rdoAccurate.TabStop = true;
            this.rdoAccurate.UseVisualStyleBackColor = true;
            this.rdoAccurate.CheckedChanged += new System.EventHandler(this.RadioAscDescChanged);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExportClicked);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnBarGraph
            // 
            resources.ApplyResources(this.btnBarGraph, "btnBarGraph");
            this.btnBarGraph.Name = "btnBarGraph";
            this.btnBarGraph.UseVisualStyleBackColor = true;
            this.btnBarGraph.Click += new System.EventHandler(this.btnBarGraph_Click);
            // 
            // ControlGroupBox
            // 
            this.ControlGroupBox.Controls.Add(this.btnBarGraph);
            this.ControlGroupBox.Controls.Add(this.rdoAccurate);
            this.ControlGroupBox.Controls.Add(this.button2);
            this.ControlGroupBox.Controls.Add(this.rdoQuizId);
            this.ControlGroupBox.Controls.Add(this.button1);
            resources.ApplyResources(this.ControlGroupBox, "ControlGroupBox");
            this.ControlGroupBox.Name = "ControlGroupBox";
            this.ControlGroupBox.TabStop = false;
            // 
            // resultListView
            // 
            resources.ApplyResources(this.resultListView, "resultListView");
            this.resultListView.HideSelection = false;
            this.resultListView.MultiSelect = false;
            this.resultListView.Name = "resultListView";
            this.resultListView.UseCompatibleStateImageBehavior = false;
            // 
            // add_map_button1
            // 
            resources.ApplyResources(this.add_map_button1, "add_map_button1");
            this.add_map_button1.Name = "add_map_button1";
            this.add_map_button1.UseVisualStyleBackColor = true;
            this.add_map_button1.Click += new System.EventHandler(this.AddMapImageAndFillPictureBoxWithResizedImage);
            // 
            // map_comboBox1
            // 
            resources.ApplyResources(this.map_comboBox1, "map_comboBox1");
            this.map_comboBox1.FormattingEnabled = true;
            this.map_comboBox1.Name = "map_comboBox1";
            this.map_comboBox1.SelectedIndexChanged += new System.EventHandler(this.map_comboBox1_SelectedIndexChanged);
            // 
            // delete_map_button8
            // 
            resources.ApplyResources(this.delete_map_button8, "delete_map_button8");
            this.delete_map_button8.Name = "delete_map_button8";
            this.delete_map_button8.UseVisualStyleBackColor = true;
            this.delete_map_button8.Click += new System.EventHandler(this.delete_map_button8_Click);
            // 
            // Exit_map_edit_button9
            // 
            resources.ApplyResources(this.Exit_map_edit_button9, "Exit_map_edit_button9");
            this.Exit_map_edit_button9.Name = "Exit_map_edit_button9";
            this.Exit_map_edit_button9.UseVisualStyleBackColor = true;
            this.Exit_map_edit_button9.Click += new System.EventHandler(this.Exit_map_edit_button9_Click);
            // 
            // lblToDate
            // 
            resources.ApplyResources(this.lblToDate, "lblToDate");
            this.lblToDate.Name = "lblToDate";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ControlBox = false;
            this.Controls.Add(this.ControlGroupBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblToDate);
            this.Controls.Add(this.lblFromDate);
            this.Controls.Add(this.lblProgBarTagLoadPercent);
            this.Controls.Add(this.progBarTagLoad);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblTagNameTest);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblCboImageName);
            this.Controls.Add(this.lblimage);
            this.Controls.Add(this.Exit_map_edit_button9);
            this.Controls.Add(this.delete_map_button8);
            this.Controls.Add(this.map_comboBox1);
            this.Controls.Add(this.map_button);
            this.Controls.Add(this.buttonFLowLineAnalysis);
            this.Controls.Add(this.add_map_button1);
            this.Controls.Add(this.buttonGuideTotal);
            this.Controls.Add(this.set_map_label1);
            this.Controls.Add(this.buttonQuizRate);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSetup);
            this.Controls.Add(this.resultListView);
            this.Controls.Add(this.txtAnalyzedData);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chartWithData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartWithData)).EndInit();
            this.ControlGroupBox.ResumeLayout(false);
            this.ControlGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSetup;
        private System.Windows.Forms.Button buttonQuizRate;
        private System.Windows.Forms.Button buttonGuideTotal;
        private System.Windows.Forms.Button buttonFLowLineAnalysis;
        private System.Windows.Forms.Button map_button;
        private System.Windows.Forms.Label set_map_label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblimage;
        private System.Windows.Forms.Label lblCboImageName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 追加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem コンテンツToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 赤外線ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 削除ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label lblTagNameTest;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWithData;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ProgressBar progBarTagLoad;
        private System.Windows.Forms.Label lblProgBarTagLoadPercent;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnalyzedData;
        private System.Windows.Forms.RadioButton rdoQuizId;
        private System.Windows.Forms.RadioButton rdoAccurate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnBarGraph;
        private System.Windows.Forms.GroupBox ControlGroupBox;
        private System.Windows.Forms.ListView resultListView;
        private System.Windows.Forms.Button add_map_button1;
        private System.Windows.Forms.ComboBox map_comboBox1;
        private System.Windows.Forms.Button delete_map_button8;
        private System.Windows.Forms.Button Exit_map_edit_button9;
        private System.Windows.Forms.Label lblToDate;
    }
}

