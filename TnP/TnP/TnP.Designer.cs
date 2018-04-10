namespace TnP
{
    partial class TnP
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TnP));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.updateButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.timeHour = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.timeMin = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.timeSec = new System.Windows.Forms.ToolStripLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.planTreeView = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.startPlanButton = new System.Windows.Forms.ToolStripButton();
            this.stopPlanButton = new System.Windows.Forms.ToolStripButton();
            this.finishPlanButton = new System.Windows.Forms.ToolStripButton();
            this.giveupPlanButton = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.generateStepButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.deleteButton,
            this.updateButton,
            this.toolStripSeparator1,
            this.toolStripTextBox1,
            this.searchButton,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripProgressBar1,
            this.toolStripLabel5,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.timeHour,
            this.toolStripLabel3,
            this.timeMin,
            this.toolStripLabel4,
            this.timeSec});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(584, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addButton
            // 
            this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(23, 22);
            this.addButton.Text = "add";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(23, 22);
            this.deleteButton.Text = "delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateButton.Image = ((System.Drawing.Image)(resources.GetObject("updateButton.Image")));
            this.updateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(23, 22);
            this.updateButton.Text = "change";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // searchButton
            // 
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.Text = "search";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Progress:";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel2.Text = "Time:";
            // 
            // timeHour
            // 
            this.timeHour.Name = "timeHour";
            this.timeHour.Size = new System.Drawing.Size(22, 22);
            this.timeHour.Text = "00";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(11, 22);
            this.toolStripLabel3.Text = ":";
            // 
            // timeMin
            // 
            this.timeMin.Name = "timeMin";
            this.timeMin.Size = new System.Drawing.Size(22, 22);
            this.timeMin.Text = "00";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(11, 22);
            this.toolStripLabel4.Text = ":";
            // 
            // timeSec
            // 
            this.timeSec.Name = "timeSec";
            this.timeSec.Size = new System.Drawing.Size(22, 22);
            this.timeSec.Text = "00";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 358);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 332);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thoughts";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 332);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Goals";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(576, 332);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tasks";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(576, 332);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Longterm";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.planTreeView);
            this.tabPage5.Controls.Add(this.toolStrip2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(576, 332);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Everyday";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // planTreeView
            // 
            this.planTreeView.Location = new System.Drawing.Point(0, 25);
            this.planTreeView.Name = "planTreeView";
            this.planTreeView.Size = new System.Drawing.Size(576, 307);
            this.planTreeView.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPlanButton,
            this.stopPlanButton,
            this.finishPlanButton,
            this.giveupPlanButton,
            this.toolStripSeparator4,
            this.generateStepButton});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(576, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // startPlanButton
            // 
            this.startPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startPlanButton.Image = ((System.Drawing.Image)(resources.GetObject("startPlanButton.Image")));
            this.startPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startPlanButton.Name = "startPlanButton";
            this.startPlanButton.Size = new System.Drawing.Size(23, 22);
            this.startPlanButton.Text = "start";
            this.startPlanButton.Click += new System.EventHandler(this.startPlanButton_Click);
            // 
            // stopPlanButton
            // 
            this.stopPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopPlanButton.Image = ((System.Drawing.Image)(resources.GetObject("stopPlanButton.Image")));
            this.stopPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopPlanButton.Name = "stopPlanButton";
            this.stopPlanButton.Size = new System.Drawing.Size(23, 22);
            this.stopPlanButton.Text = "Stop";
            this.stopPlanButton.Click += new System.EventHandler(this.stopPlanButton_Click);
            // 
            // finishPlanButton
            // 
            this.finishPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.finishPlanButton.Image = ((System.Drawing.Image)(resources.GetObject("finishPlanButton.Image")));
            this.finishPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.finishPlanButton.Name = "finishPlanButton";
            this.finishPlanButton.Size = new System.Drawing.Size(23, 22);
            this.finishPlanButton.Text = "Done";
            this.finishPlanButton.Click += new System.EventHandler(this.finishPlanButton_Click);
            // 
            // giveupPlanButton
            // 
            this.giveupPlanButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.giveupPlanButton.Image = ((System.Drawing.Image)(resources.GetObject("giveupPlanButton.Image")));
            this.giveupPlanButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.giveupPlanButton.Name = "giveupPlanButton";
            this.giveupPlanButton.Size = new System.Drawing.Size(23, 22);
            this.giveupPlanButton.Text = "Give up";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // generateStepButton
            // 
            this.generateStepButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.generateStepButton.Image = ((System.Drawing.Image)(resources.GetObject("generateStepButton.Image")));
            this.generateStepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.generateStepButton.Name = "generateStepButton";
            this.generateStepButton.Size = new System.Drawing.Size(23, 22);
            this.generateStepButton.Text = "generate steps";
            this.generateStepButton.Click += new System.EventHandler(this.generateStepButton_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(26, 22);
            this.toolStripLabel5.Text = "0%";
            // 
            // TnP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 382);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TnP";
            this.Text = "Task and Plan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TnP_FormClosing);
            this.Load += new System.EventHandler(this.TnP_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton startPlanButton;
        private System.Windows.Forms.ToolStripButton stopPlanButton;
        private System.Windows.Forms.ToolStripButton finishPlanButton;
        private System.Windows.Forms.ToolStripButton giveupPlanButton;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton updateButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel timeHour;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel timeMin;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel timeSec;
        private System.Windows.Forms.TreeView planTreeView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton generateStepButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
    }
}

