namespace hhi_local {
    partial class Form_Prefix {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btn_ok = new System.Windows.Forms.Button();
            this.tb_prefixname = new System.Windows.Forms.MaskedTextBox();
            this.tb_start = new System.Windows.Forms.MaskedTextBox();
            this.tb_end = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_exclude = new System.Windows.Forms.TextBox();
            this.tb_include = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(210, 225);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(79, 26);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "完成";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // tb_prefixname
            // 
            this.tb_prefixname.Location = new System.Drawing.Point(71, 12);
            this.tb_prefixname.Name = "tb_prefixname";
            this.tb_prefixname.Size = new System.Drawing.Size(216, 21);
            this.tb_prefixname.TabIndex = 1;
            // 
            // tb_start
            // 
            this.tb_start.Location = new System.Drawing.Point(14, 63);
            this.tb_start.Name = "tb_start";
            this.tb_start.Size = new System.Drawing.Size(273, 21);
            this.tb_start.TabIndex = 2;
            this.tb_start.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_start_KeyPress);
            // 
            // tb_end
            // 
            this.tb_end.Location = new System.Drawing.Point(14, 102);
            this.tb_end.Name = "tb_end";
            this.tb_end.Size = new System.Drawing.Size(273, 21);
            this.tb_end.TabIndex = 3;
            this.tb_end.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_end_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "预设名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "起始学号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "结束学号";
            // 
            // tb_exclude
            // 
            this.tb_exclude.Location = new System.Drawing.Point(16, 198);
            this.tb_exclude.Name = "tb_exclude";
            this.tb_exclude.Size = new System.Drawing.Size(273, 21);
            this.tb_exclude.TabIndex = 8;
            this.tb_exclude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tb_include
            // 
            this.tb_include.Location = new System.Drawing.Point(14, 159);
            this.tb_include.Name = "tb_include";
            this.tb_include.Size = new System.Drawing.Size(273, 21);
            this.tb_include.TabIndex = 9;
            this.tb_include.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "包括额外学号(用“;”隔开)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "去除范围内的学号(用“;”隔开)";
            // 
            // Form_Prefix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 261);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_include);
            this.Controls.Add(this.tb_exclude);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_end);
            this.Controls.Add(this.tb_start);
            this.Controls.Add(this.tb_prefixname);
            this.Controls.Add(this.btn_ok);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Prefix";
            this.Text = "添加预设";
            this.Load += new System.EventHandler(this.Form_Prefix_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.MaskedTextBox tb_prefixname;
        private System.Windows.Forms.MaskedTextBox tb_start;
        private System.Windows.Forms.MaskedTextBox tb_end;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_exclude;
        private System.Windows.Forms.TextBox tb_include;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}