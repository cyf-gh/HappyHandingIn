using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using stLib_CS;
using stLib_CS.HastyFoo;
using stLib_CS.Net;
using hhi_modules;
using stLib_CS.Generic;

namespace hhi_client {
    public partial class Main_Frame : Form {
        private static Client m_Client;
        private static List<HHI_ServerInfo> m_serveinfos = new List<HHI_ServerInfo>();
        private long m_sleeptime;
        public Main_Frame() {
            CenterToScreen();
            InitializeComponent();
        }
        private HHI_HandIn GetCurrentHandIn() {
            foreach( var item in HHI_Module.listHandInData ) {
                if( item.Name == comboBox_handIns.Text ) {
                    return item;
                }
            }
            return null;
        }
        private void LoadAllInit() {
            stLib_CS.File.Ini tIni = new stLib_CS.File.Ini( System.IO.Directory.GetCurrentDirectory() + "\\config.ini" );

            if( !tIni.Exist() ) {
                MessageBox.Show( "ini文件不存在，请创建。" );
                this.Close();
                return;
            }
            string strCount = tIni.ReadValue( "res", "totalcount" );

            for( int i = 0; i < Convert.ToInt32( strCount ); i++ ) {
                HHI_ServerInfo info = new HHI_ServerInfo();
                info.Port = tIni.ReadValue( i.ToString(), "port" );
                info.IP = tIni.ReadValue( i.ToString(), "ip" );
                info.Name = tIni.ReadValue( i.ToString(), "name" );
                info.ID = i;
                m_serveinfos.Add( info );
            }
        }

        private HHI_Prefix GetCurrentHandInsPrefix() {
            HHI_HandIn hi = GetCurrentHandIn();
            foreach( var prefix in HHI_Module.listPrefixes ) {
                if( prefix.Name == hi.PrefixName ) {
                    return prefix;
                }
            }
            return null;
        }

        private HHI_ServerInfo GetCurrentServerInfo() {
            foreach( var item in m_serveinfos ) {
                if( item.Name == comboBox_class.Text ) {
                    return item;
                }
            }
            return null;
        }

        private void MainFrame_Load( Object sender, EventArgs e ) {
            btn_attach.Enabled = false;
            btn_pull_info.Enabled = false;
            comboBox_handIns.Enabled = false;
            LoadAllInit();
            comboBox_class.DataSource = m_serveinfos;
            comboBox_class.ValueMember = "id";
            comboBox_class.DisplayMember = "name";
            this.Text = "未连接";
        }

        private async void btn_attach_Click( Object sender, EventArgs e ) {
            string m_path = null;
            HHI_HandIn hi = GetCurrentHandIn();

            if( hi.IsSubItemFolder ) {
                m_path = stLib_CS.HastyFoo.Dialog.GetFolderPath();
            } else {
                m_path = stLib_CS.HastyFoo.Dialog.GetFileName();
            }
            if( m_path == null ) {
                return;
            }
            string name = m_path.Substring( m_path.LastIndexOf( '\\' ) + 1 );
            string index;
            if( !HHI_Module.IndexExist( name, GetCurrentHandInsPrefix(), out index ) ) {
                return;
            }

            if( hi.IsSubItemFolder ) {
                await SendFiles( m_path );
            } else {
                await SendFile( m_path );
            }
        }

        private async Task<int> SendFile( string path ) {
            NStream stream = m_Client.stream;
            FileInfo file = new FileInfo( path );
            if( !CurrentPingStatus() ) {
                m_sleeptime = 0;
            }
            await stream.WriteInt32( 1 );
            await stream.WriteString( GetCurrentHandIn().Path );
            if( m_sleeptime == 0 ) {
                m_sleeptime = file.Length * 1000 / 1024 / 200;
            }
            Sleep();

            FileStream fileStream;
            try {
                fileStream = file.OpenRead();
            } catch( Exception e ) {
                MessageBox.Show( "无法打开指定的文件" );
                return 0;
            }
            await stream.WriteInt64( file.Length );
            await stream.WriteString( file.Name );

            int res = await stream.WriteBigFrom( fileStream );

            MessageBox.Show( "传输成功" );
            RefreshText();
            return 0;
        }
        private async Task<int> SendFiles( string path ) {
            List<FileInfo> files = stLib_CS.File.FileHelper.GetFiles( path );
            int i = 0;
            NStream stream = m_Client.stream;
            if( !CurrentPingStatus() ) {
                m_sleeptime = 0;
            }
            await stream.WriteInt32( files.Count );
            await stream.WriteString( GetCurrentHandIn().Path + path.Substring( path.LastIndexOf( '\\' ) ) );

            foreach( var file in files ) {
                if( m_sleeptime == 0 ) {
                    m_sleeptime = file.Length * 1000 / 1024 / 200;
                }
                Sleep();
                FileStream fileStream;
                try {
                    fileStream = file.OpenRead();
                } catch( Exception e ) {
                    MessageBox.Show( "无法打开指定的文件" );
                    return 0;
                }
                await stream.WriteInt64( file.Length );
                await stream.WriteString( file.Name );

                int res = await stream.WriteBigFrom( fileStream );
                i++;
                this.Text = "正在发送第" + i.ToString() + "个文件";
            }
            MessageBox.Show( "传输成功" );
            RefreshText();
            return 0;
        }

        private void btn_pull_info_Click( Object sender, EventArgs e ) {
            HHI_HandIn hhi = GetCurrentHandIn();
            MessageBox.Show(
                "作业名称：" + hhi.Name +
                "\n作业路径：" + hhi.Path +
                "\n作业预设方案：" + hhi.PrefixName
                );
        }

        private void Main_Frame_FormClosing( Object sender, FormClosingEventArgs e ) {
            try {
                m_Client.Disconnect();
            } catch( Exception ee ) {
                return;
            }
        }

        private async void btn_ConToServer_Click( Object sender, EventArgs e ) {
            if( m_Client == null ) {
                goto CON;
            }
            if( m_Client.Connected() && GetCurrentServerInfo().IP == m_Client.IPAddress ) {
                MessageBox.Show( "服务器已连接" );
                return;
            } else if( m_Client.Connected() && GetCurrentServerInfo().IP == m_Client.IPAddress ) {
                m_Client.Disconnect();
            }
CON:
//if( !CurrentPingStatus() ) {
//    return;
//}
            m_Client = new Client( GetCurrentServerInfo().IP, GetCurrentServerInfo().Port );
            if( 1 == await m_Client.Connect() ) {
                MessageBox.Show( "连接失败" );
                return;
            }
            await m_Client.fileTrans.DownloadFiles( HHI_Module.m_dataPath );

            Sleep();

            HHI_Module.LoadPrefixs();
            HHI_Module.LoadHandIns();
            comboBox_handIns.DataSource = HHI_Module.listHandInData;
            comboBox_handIns.ValueMember = "id";
            comboBox_handIns.DisplayMember = "name";
            btn_attach.Enabled = true;
            btn_pull_info.Enabled = true;
            comboBox_handIns.Enabled = true;
            RefreshText();
        }
        void RefreshText() {
            this.Text = "已连接 服务器 " + "名称 " + GetCurrentServerInfo().Name + "\t IP " + m_Client.IPAddress + "\t 端口 " + m_Client.Port;
        }
        bool CurrentPingStatus() {
            for( int i = 0; i < 5; i++ ) {
                Ping ping = new Ping( GetCurrentServerInfo().IP );
                if( !ping.IsSuccess() ) {
                    MessageBox.Show( "服务器Ping失败，请检查网络" );
                    return false;
                } else {
                    m_sleeptime += ping.GetRoundTime();
                }
            }
            m_sleeptime = m_sleeptime / 5 + 10;
            return true;
        }
        void Sleep() {
            System.Threading.Thread.Sleep( (int)m_sleeptime );
        }
    }
}
