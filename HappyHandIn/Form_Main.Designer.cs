namespace HappyHandIn
{
    partial class Form_Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newHandInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePrefixsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveHHIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prefixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.static_handIn = new System.Windows.Forms.GroupBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.comboBox_handIns = new System.Windows.Forms.ComboBox();
            this.label_resultOutPut = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.static_handIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.prefixToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newHandInToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newHandInToolStripMenuItem
            // 
            this.newHandInToolStripMenuItem.Name = "newHandInToolStripMenuItem";
            this.newHandInToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.newHandInToolStripMenuItem.Text = "New HandIn";
            this.newHandInToolStripMenuItem.Click += new System.EventHandler(this.newHandInToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.saveAllToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.savePrefixsToolStripMenuItem,
            this.saveHHIToolStripMenuItem,
            this.saveLogToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // savePrefixsToolStripMenuItem
            // 
            this.savePrefixsToolStripMenuItem.Name = "savePrefixsToolStripMenuItem";
            this.savePrefixsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.savePrefixsToolStripMenuItem.Text = "Save Prefixs";
            this.savePrefixsToolStripMenuItem.Click += new System.EventHandler(this.savePrefixsToolStripMenuItem_Click);
            // 
            // saveHHIToolStripMenuItem
            // 
            this.saveHHIToolStripMenuItem.Name = "saveHHIToolStripMenuItem";
            this.saveHHIToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveHHIToolStripMenuItem.Text = "Save HHI";
            this.saveHHIToolStripMenuItem.Click += new System.EventHandler(this.saveHHIToolStripMenuItem_Click);
            // 
            // saveLogToolStripMenuItem
            // 
            this.saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            this.saveLogToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveLogToolStripMenuItem.Text = "保存日志";
            this.saveLogToolStripMenuItem.Click += new System.EventHandler(this.saveLogToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // prefixToolStripMenuItem
            // 
            this.prefixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem});
            this.prefixToolStripMenuItem.Name = "prefixToolStripMenuItem";
            this.prefixToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.prefixToolStripMenuItem.Text = "Prefix";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.newToolStripMenuItem.Text = "新建";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.editToolStripMenuItem.Text = "编辑";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // static_handIn
            // 
            this.static_handIn.Controls.Add(this.btn_check);
            this.static_handIn.Controls.Add(this.comboBox_handIns);
            this.static_handIn.Location = new System.Drawing.Point(12, 33);
            this.static_handIn.Name = "static_handIn";
            this.static_handIn.Size = new System.Drawing.Size(339, 61);
            this.static_handIn.TabIndex = 1;
            this.static_handIn.TabStop = false;
            this.static_handIn.Text = "HandIn Select";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(261, 19);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(72, 20);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // comboBox_handIns
            // 
            this.comboBox_handIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_handIns.FormattingEnabled = true;
            this.comboBox_handIns.Location = new System.Drawing.Point(6, 20);
            this.comboBox_handIns.Name = "comboBox_handIns";
            this.comboBox_handIns.Size = new System.Drawing.Size(249, 20);
            this.comboBox_handIns.TabIndex = 1;
            // 
            // label_resultOutPut
            // 
            this.label_resultOutPut.BackColor = System.Drawing.Color.White;
            this.label_resultOutPut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_resultOutPut.Font = new System.Drawing.Font("SimSun", 10F);
            this.label_resultOutPut.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_resultOutPut.Location = new System.Drawing.Point(12, 97);
            this.label_resultOutPut.Name = "label_resultOutPut";
            this.label_resultOutPut.Size = new System.Drawing.Size(339, 412);
            this.label_resultOutPut.TabIndex = 2;
            this.label_resultOutPut.Text = "label1";
            this.label_resultOutPut.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(369, 518);
            this.Controls.Add(this.label_resultOutPut);
            this.Controls.Add(this.static_handIn);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form_Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "快乐收作业";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.static_handIn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newHandInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prefixToolStripMenuItem;
        private System.Windows.Forms.GroupBox static_handIn;
        private System.Windows.Forms.ComboBox comboBox_handIns;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label_resultOutPut;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePrefixsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveHHIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogToolStripMenuItem;
    }
}