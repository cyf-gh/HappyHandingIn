using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;

namespace HappyHandIn {
    public partial class Form_Main : Form {
        public Form_Main() {
            InitializeComponent();
            CenterToScreen();
        }
        private string m_output;
        private string m_log;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void newHandInToolStripMenuItem_Click(Object sender, EventArgs e) {
            Form_CreateNewHandIn tForm_CreateNewHandIn = new Form_CreateNewHandIn();
            tForm_CreateNewHandIn.ShowDialog();

            bool isValiedData;
            HHI_HandIn data = tForm_CreateNewHandIn.GetData(out isValiedData);

            if (isValiedData) {
                HHI_Module.listHandInData.Add(data);
            }
        }

        private void Form_Main_Load(Object sender, EventArgs e) {
            HHI_Module.LoadPrefixs();
            HHI_Module.LoadHandIns();
            label_resultOutPut.Text = cn_strs.str_weclome;
            static_handIn.Text = cn_strs.str_select_handin;
            fileToolStripMenuItem.Text = "文件";
            newHandInToolStripMenuItem.Text = "创建新方案";
            exitToolStripMenuItem.Text = "退出";
            prefixToolStripMenuItem.Text = "预设";
            saveToolStripMenuItem.Text = "保存...";
            saveHHIToolStripMenuItem.Text = "保存所有新方案";
            savePrefixsToolStripMenuItem.Text = "保存所有预设";
            saveAllToolStripMenuItem.Text = "保存所有";
            btn_check.Text = "检查";
            comboBox_handIns.DataSource = HHI_Module.listHandInData;
            comboBox_handIns.ValueMember = "id";
            comboBox_handIns.DisplayMember = "name";
        }

        private void newToolStripMenuItem_Click(Object sender, EventArgs e) {
            Form_Prefix tForm_prefix = new Form_Prefix();
            tForm_prefix.ShowDialog();
        }

        private void btn_check_Click(Object sender, EventArgs e) {
            m_log += m_output;
            m_output = "";
            ProcessCheck();
        }

        private void ProcessCheck() {
            HHI_Prefix tprefix = null;
            List<int> digit = new List<int>();
            List<string> files;

            foreach (var item in HHI_Module.listHandInData) {
                if (item.name == comboBox_handIns.Text) {
                    // get prefix
                    foreach (var prefix in HHI_Module.listPrefixes) {
                        if (prefix.name == item.prefix_name) {
                            tprefix = prefix;
                        }
                    }
                    if ( tprefix == null ) {
                        m_output += "错误：无该预设\n";
                    }
                    // process folder
                    if (item.isSubItemFolder) {
                        // process file
                        files = HHI_Module.FindFolders(item.path);
                    } else {
                    // process file
                        files = HHI_Module.FindFile(item.path);
                    }

                    for (int i = 0; i < (tprefix.end - tprefix.start + 1); i++) {
                        digit.Add(tprefix.start + i);
                    }
                    foreach (var file in files) {
                        string pattern = "[0-9]";
                        string strRet = "";
                        MatchCollection results = Regex.Matches(file, pattern);
                        foreach (var v in results) {
                            strRet += v.ToString();
                        }
                        for (int j = 0; j < digit.Count; ++j) {
                            if (digit[j] == Convert.ToInt32(strRet)) {
                                digit.Remove(digit[j]);
                                break;
                            }
                        }
                    }

                    m_output += "\n" + "[" + System.DateTime.Now.ToString() + "]" +"\n" + "作业名: " + item.name + "\n\n";
                    // !process file
                    if (digit.Count == 0) {
                        m_output += "已全部收齐！";
                    } else {
                        m_output += "以下编号尚未交作业：" + "\n";
                        foreach (var d in digit) {
                            m_output += d.ToString() + "   ";
                        }
                        m_output += "\n" + "共" + digit.Count.ToString() +"人";
                    }
                    
                    label_resultOutPut.Text = m_output;
                    return;
                }
            }
        }

        private void saveToolStripMenuItem_Click(Object sender, EventArgs e) {

        }

        private void savePrefixsToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SavePrefixs();
        }

        private void saveHHIToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SaveHandInDatum();
        }

        private void saveAllToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SavePrefixs();
            HHI_Module.SaveHandInDatum();
        }

        private void 关于ToolStripMenuItem_Click(Object sender, EventArgs e) {
            MessageBox.Show("cyf 2018\nMail: cyf-ms@hotmail.com\n本软件遵守类zlib开源协议");
        }

        private void saveLogToolStripMenuItem_Click(Object sender, EventArgs e) {
            HHI_Module.SaveLog(m_log);
        }
    }
}
