namespace TnP.SubForm
{
    partial class TaskBook
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
            this.taskTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.allTaskList = new System.Windows.Forms.ListBox();
            this.sTaskList = new System.Windows.Forms.ListBox();
            this.subtaskList = new System.Windows.Forms.ListBox();
            this.toSTaskButton = new System.Windows.Forms.Button();
            this.toSubtaskButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sTaskUpButton = new System.Windows.Forms.Button();
            this.sTaskDownButton = new System.Windows.Forms.Button();
            this.subtaskUpButton = new System.Windows.Forms.Button();
            this.subtaskDownButton = new System.Windows.Forms.Button();
            this.delSTaskButton = new System.Windows.Forms.Button();
            this.delSubtaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // taskTextBox
            // 
            this.taskTextBox.Location = new System.Drawing.Point(14, 12);
            this.taskTextBox.Name = "taskTextBox";
            this.taskTextBox.Size = new System.Drawing.Size(170, 21);
            this.taskTextBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(211, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // allTaskList
            // 
            this.allTaskList.FormattingEnabled = true;
            this.allTaskList.ItemHeight = 12;
            this.allTaskList.Location = new System.Drawing.Point(12, 67);
            this.allTaskList.Name = "allTaskList";
            this.allTaskList.Size = new System.Drawing.Size(120, 304);
            this.allTaskList.TabIndex = 9;
            // 
            // sTaskList
            // 
            this.sTaskList.FormattingEnabled = true;
            this.sTaskList.ItemHeight = 12;
            this.sTaskList.Location = new System.Drawing.Point(169, 66);
            this.sTaskList.Name = "sTaskList";
            this.sTaskList.Size = new System.Drawing.Size(120, 136);
            this.sTaskList.TabIndex = 10;
            this.sTaskList.SelectedIndexChanged += new System.EventHandler(this.sTaskList_SelectedIndexChanged);
            // 
            // subtaskList
            // 
            this.subtaskList.FormattingEnabled = true;
            this.subtaskList.ItemHeight = 12;
            this.subtaskList.Location = new System.Drawing.Point(169, 235);
            this.subtaskList.Name = "subtaskList";
            this.subtaskList.Size = new System.Drawing.Size(120, 136);
            this.subtaskList.TabIndex = 11;
            // 
            // toSTaskButton
            // 
            this.toSTaskButton.Location = new System.Drawing.Point(138, 96);
            this.toSTaskButton.Name = "toSTaskButton";
            this.toSTaskButton.Size = new System.Drawing.Size(25, 23);
            this.toSTaskButton.TabIndex = 12;
            this.toSTaskButton.Text = "=>";
            this.toSTaskButton.UseVisualStyleBackColor = true;
            this.toSTaskButton.Click += new System.EventHandler(this.toSTaskButton_Click);
            // 
            // toSubtaskButton
            // 
            this.toSubtaskButton.Location = new System.Drawing.Point(138, 257);
            this.toSubtaskButton.Name = "toSubtaskButton";
            this.toSubtaskButton.Size = new System.Drawing.Size(25, 23);
            this.toSubtaskButton.TabIndex = 13;
            this.toSubtaskButton.Text = "=>";
            this.toSubtaskButton.UseVisualStyleBackColor = true;
            this.toSubtaskButton.Click += new System.EventHandler(this.toSubtaskButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "All Subtasks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Specific Tasks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Subtasks";
            // 
            // sTaskUpButton
            // 
            this.sTaskUpButton.Location = new System.Drawing.Point(295, 84);
            this.sTaskUpButton.Name = "sTaskUpButton";
            this.sTaskUpButton.Size = new System.Drawing.Size(30, 35);
            this.sTaskUpButton.TabIndex = 17;
            this.sTaskUpButton.Text = "up";
            this.sTaskUpButton.UseVisualStyleBackColor = true;
            this.sTaskUpButton.Click += new System.EventHandler(this.sTaskUpButton_Click);
            // 
            // sTaskDownButton
            // 
            this.sTaskDownButton.Location = new System.Drawing.Point(295, 146);
            this.sTaskDownButton.Name = "sTaskDownButton";
            this.sTaskDownButton.Size = new System.Drawing.Size(30, 35);
            this.sTaskDownButton.TabIndex = 18;
            this.sTaskDownButton.Text = "down";
            this.sTaskDownButton.UseVisualStyleBackColor = true;
            this.sTaskDownButton.Click += new System.EventHandler(this.sTaskDownButton_Click);
            // 
            // subtaskUpButton
            // 
            this.subtaskUpButton.Location = new System.Drawing.Point(295, 257);
            this.subtaskUpButton.Name = "subtaskUpButton";
            this.subtaskUpButton.Size = new System.Drawing.Size(30, 35);
            this.subtaskUpButton.TabIndex = 19;
            this.subtaskUpButton.Text = "up";
            this.subtaskUpButton.UseVisualStyleBackColor = true;
            this.subtaskUpButton.Click += new System.EventHandler(this.subtaskUpButton_Click);
            // 
            // subtaskDownButton
            // 
            this.subtaskDownButton.Location = new System.Drawing.Point(295, 313);
            this.subtaskDownButton.Name = "subtaskDownButton";
            this.subtaskDownButton.Size = new System.Drawing.Size(30, 35);
            this.subtaskDownButton.TabIndex = 20;
            this.subtaskDownButton.Text = "down";
            this.subtaskDownButton.UseVisualStyleBackColor = true;
            this.subtaskDownButton.Click += new System.EventHandler(this.subtaskDownButton_Click);
            // 
            // delSTaskButton
            // 
            this.delSTaskButton.Location = new System.Drawing.Point(138, 152);
            this.delSTaskButton.Name = "delSTaskButton";
            this.delSTaskButton.Size = new System.Drawing.Size(25, 23);
            this.delSTaskButton.TabIndex = 21;
            this.delSTaskButton.Text = "<=";
            this.delSTaskButton.UseVisualStyleBackColor = true;
            this.delSTaskButton.Click += new System.EventHandler(this.delSTaskButton_Click);
            // 
            // delSubtaskButton
            // 
            this.delSubtaskButton.Location = new System.Drawing.Point(138, 313);
            this.delSubtaskButton.Name = "delSubtaskButton";
            this.delSubtaskButton.Size = new System.Drawing.Size(25, 23);
            this.delSubtaskButton.TabIndex = 22;
            this.delSubtaskButton.Text = "<=";
            this.delSubtaskButton.UseVisualStyleBackColor = true;
            this.delSubtaskButton.Click += new System.EventHandler(this.delSubtaskButton_Click);
            // 
            // TaskBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 382);
            this.Controls.Add(this.delSubtaskButton);
            this.Controls.Add(this.delSTaskButton);
            this.Controls.Add(this.subtaskDownButton);
            this.Controls.Add(this.subtaskUpButton);
            this.Controls.Add(this.sTaskDownButton);
            this.Controls.Add(this.sTaskUpButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toSubtaskButton);
            this.Controls.Add(this.toSTaskButton);
            this.Controls.Add(this.subtaskList);
            this.Controls.Add(this.sTaskList);
            this.Controls.Add(this.allTaskList);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.taskTextBox);
            this.Name = "TaskBook";
            this.Text = "TaskBook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskBook_FormClosing);
            this.Load += new System.EventHandler(this.TaskBook_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox taskTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListBox allTaskList;
        private System.Windows.Forms.ListBox sTaskList;
        private System.Windows.Forms.ListBox subtaskList;
        private System.Windows.Forms.Button toSTaskButton;
        private System.Windows.Forms.Button toSubtaskButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button sTaskUpButton;
        private System.Windows.Forms.Button sTaskDownButton;
        private System.Windows.Forms.Button subtaskUpButton;
        private System.Windows.Forms.Button subtaskDownButton;
        private System.Windows.Forms.Button delSTaskButton;
        private System.Windows.Forms.Button delSubtaskButton;
    }
}