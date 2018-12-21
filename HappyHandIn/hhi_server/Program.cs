using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using stLib_CS;
using hhi_modules;
using stLib_CS.Net;

namespace hhi_server {
    static class Program {
        private static string m_path;
        private static string m_port;
        private static int m_maxBackLog;
        // private static Server m_serve;
        private static Server m_server;
        static private void LoadAllInit() {
            m_path = "c:\\dev";

            stLib_CS.File.Ini tIni = new stLib_CS.File.Ini( System.IO.Directory.GetCurrentDirectory() + "\\config.ini" );

            if( !tIni.Exist() ) {
                System.Console.WriteLine( "ini文件不存在，请创建。" );
                System.Console.ReadKey();
                return;
            }
            m_port = tIni.ReadValue( "net", "port" );
            m_maxBackLog = Convert.ToInt32( tIni.ReadValue( "net", "maxbacklog" ) );
        }
        static private void PrintAllIPs() {
            IPHostEntry ipHostInfo = Dns.GetHostEntry( Dns.GetHostName() );
            foreach( IPAddress ipa in ipHostInfo.AddressList ) {
                if( ipa.AddressFamily == AddressFamily.InterNetwork ) {
                    System.Console.WriteLine( ipa.ToString() );
                    break;
                }
            }
        }
        static async void DownloadFiles() {
            m_server = new Server( "127.0.0.1", Convert.ToInt32( m_port ) );
            await m_server.WaitForConnect();

            await m_server.fileTrans.SendFiles( HHI_Module.m_dataPath );
            Console.WriteLine( "data files sent." );

            NStream stream = m_server.stream;

            Int32 nfileCount = await stream.ReadInt32();
            m_path = await stream.ReadString();
            if( false == System.IO.Directory.Exists( m_path ) ) {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory( m_path );
            }
            System.Console.WriteLine( "Client：" + "" + " Start uploading." );
            System.Console.WriteLine( "[File Count]:" + nfileCount.ToString() );

            for( int i = 0; i < nfileCount; i++ ) {
                System.Console.WriteLine( "\t[File Index]:" + i.ToString() );
                // 获得文件信息
                long fileLength = await stream.ReadInt64();
                string fileName = await stream.ReadString();

                System.Console.WriteLine( "\t\t[File Name]:" + fileName );
                System.Console.WriteLine( "\t\t[File Length]:" + fileLength.ToString() );

                FileStream fileStream = File.Open( m_path + "/" + fileName, FileMode.Create );

                await stream.ReadBigTo( fileStream, fileLength );

                System.Console.WriteLine( "\t[File]:" + fileName + "Received.\n" );
            }

        }
        static void Main( string[] args ) {
            LoadAllInit();
            PrintAllIPs();

            DownloadFiles();
            while( true ) {
                Thread.Sleep( 2 );
            }
        }
    }

}
