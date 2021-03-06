﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hhi_modules;

namespace hhi_local {
    public partial class Form_Prefix : Form {
        public Form_Prefix() {
            InitializeComponent();
            CenterToScreen();
        }

        private void Form_Prefix_Load(Object sender, EventArgs e) {

        }

        private void btn_ok_Click(Object sender, EventArgs e) {
            if (tb_prefixname.Text == "" || tb_start.Text == "" || tb_end.Text == "" ) {
                MessageBox.Show("您还有内容未输入");
                return;
            }
            foreach (var item in HHI_Module.listPrefixes) {
                if (item.Name == tb_prefixname.Text) {
                    MessageBox.Show("已存在预设 "+item.Name);
                    return;
                }
            }
            HHI_Prefix prefix = new HHI_Prefix();
            prefix.ID = HHI_Module.listPrefixes.Count;
            prefix.Name = tb_prefixname.Text;
            prefix.Start = Convert.ToInt32(tb_start.Text);
            prefix.End = Convert.ToInt32(tb_end.Text);
            prefix.Include = tb_include.Text;
            prefix.Exclude = tb_exclude.Text;
            HHI_Module.listPrefixes.Add(prefix);
            this.Close();
        }

        private void tb_start_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void tb_end_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            } 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar)&& e.KeyChar!=59)
            {
                e.Handled = true;
            } 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar) && e.KeyChar != 59)
            {
                e.Handled = true;
            } 
        }
    }
}
