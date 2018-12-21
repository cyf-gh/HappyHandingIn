namespace hhi_client
{
    partial class Main_Frame
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
            this.btn_attach = new System.Windows.Forms.Button();
            this.comboBox_handIns = new System.Windows.Forms.ComboBox();
            this.btn_pull_info = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_class = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_to_server = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_attach
            // 
            this.btn_attach.Enabled = false;
            this.btn_attach.Location = new System.Drawing.Point(294, 138);
            this.btn_attach.Name = "btn_attach";
            this.btn_attach.Size = new System.Drawing.Size(118, 23);
            this.btn_attach.TabIndex = 4;
            this.btn_attach.Text = "提交作业";
            this.btn_attach.UseVisualStyleBackColor = true;
            this.btn_attach.Click += new System.EventHandler(this.btn_attach_Click);
            // 
            // comboBox_handIns
            // 
            this.comboBox_handIns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_handIns.FormattingEnabled = true;
            this.comboBox_handIns.Location = new System.Drawing.Point(12, 140);
            this.comboBox_handIns.Name = "comboBox_handIns";
            this.comboBox_handIns.Size = new System.Drawing.Size(278, 21);
            this.comboBox_handIns.TabIndex = 3;
            // 
            // btn_pull_info
            // 
            this.btn_pull_info.Location = new System.Drawing.Point(294, 167);
            this.btn_pull_info.Name = "btn_pull_info";
            this.btn_pull_info.Size = new System.Drawing.Size(118, 23);
            this.btn_pull_info.TabIndex = 8;
            this.btn_pull_info.Text = "当前方案信息";
            this.btn_pull_info.UseVisualStyleBackColor = true;
            this.btn_pull_info.Click += new System.EventHandler(this.btn_pull_info_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "作业名：";
            // 
            // comboBox_class
            // 
            this.comboBox_class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_class.FormattingEnabled = true;
            this.comboBox_class.Location = new System.Drawing.Point(12, 52);
            this.comboBox_class.Name = "comboBox_class";
            this.comboBox_class.Size = new System.Drawing.Size(278, 21);
            this.comboBox_class.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "班级：";
            // 
            // btn_to_server
            // 
            this.btn_to_server.Location = new System.Drawing.Point(294, 50);
            this.btn_to_server.Name = "btn_to_server";
            this.btn_to_server.Size = new System.Drawing.Size(118, 23);
            this.btn_to_server.TabIndex = 14;
            this.btn_to_server.Text = "连接";
            this.btn_to_server.UseVisualStyleBackColor = true;
            this.btn_to_server.Click += new System.EventHandler(this.btn_ConToServer_Click);
            // 
            // Main_Frame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 208);
            this.Controls.Add(this.btn_to_server);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_class);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_pull_info);
            this.Controls.Add(this.btn_attach);
            this.Controls.Add(this.comboBox_handIns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main_Frame";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Frame_FormClosing);
            this.Load += new System.EventHandler(this.MainFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_attach;
        private System.Windows.Forms.ComboBox comboBox_handIns;
        private System.Windows.Forms.Button btn_pull_info;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_class;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_to_server;
    }
}

