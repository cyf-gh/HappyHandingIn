using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace HappyHandIn {
    public class HHI_Module {
        public static List<HHI_HandIn> listHandInData = new List<HHI_HandIn>();
        public static List<HHI_Prefix> listPrefixes = new List<HHI_Prefix>();
        private static string m_currentPath = Environment.CurrentDirectory;
        private static string m_logPath = Environment.CurrentDirectory + "\\log\\";
        private static string m_prefixPath = Environment.CurrentDirectory + "\\prefixs.xml";
        private static string m_handInPath = Environment.CurrentDirectory + "\\hhi.xml";
        private static XmlDocument m_prefixxml = new XmlDocument();
        private static  XmlDocument m_handInxml = new XmlDocument();

        public static void LoadPrefixs() {
            m_prefixxml.Load(m_prefixPath);
            //<prefixs>
            XmlNode rootNode = m_prefixxml.SelectSingleNode("prefixs");
            XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
            //<prefix>
            int i = 0;
            foreach (XmlNode node in firstLevelNodeList) {
                HHI_Prefix tmp = new HHI_Prefix();
                tmp.name = node.Attributes["name"].Value;
                // get infos
                XmlNodeList prefixInfos = node.ChildNodes;
                tmp.start = Convert.ToInt32(prefixInfos.Item(0).InnerText);
                tmp.end = Convert.ToInt32(prefixInfos.Item(1).InnerText);
                tmp.id = i;
                listPrefixes.Add(tmp);
                ++i;
            }
        }
        public static void LoadHandIns() {
            m_handInxml.Load(m_handInPath);
            //<prefixs>
            XmlNode rootNode = m_handInxml.SelectSingleNode("hhis");
            XmlNodeList firstLevelNodeList = rootNode.ChildNodes;
            //<prefix>
            int i = 0;
            foreach (XmlNode node in firstLevelNodeList) {
                HHI_HandIn tmp = new HHI_HandIn();
                tmp.name = node.Attributes["name"].Value;
                tmp.isSubItemFolder = Convert.ToBoolean( node.Attributes["isSubItemFolder"].Value );
                // get infos
                XmlNodeList prefixInfos = node.ChildNodes;
                tmp.path = prefixInfos.Item(0).InnerText;
                tmp.regex = prefixInfos.Item(1).InnerText;
                tmp.prefix_name = prefixInfos.Item(2).InnerText;
                tmp.id = i;
                listHandInData.Add(tmp);
                ++i;
            }

        }
        public static void SaveHandInDatum() {
            XmlDocument handinXML = new XmlDocument();
            XmlElement rootElement = handinXML.CreateElement("hhis");
            handinXML.AppendChild(rootElement);
            foreach (var item in listHandInData) {
                XmlElement hhi = handinXML.CreateElement("hhi");
                hhi.SetAttribute("name", item.name);
                hhi.SetAttribute("isSubItemFolder", item.isSubItemFolder.ToString());

                XmlElement path = handinXML.CreateElement("path");
                path.InnerText = item.path;
                XmlElement regex = handinXML.CreateElement("regex");
                regex.InnerText = item.regex;
                XmlElement prefix_name = handinXML.CreateElement("prefix_name");
                prefix_name.InnerText = item.prefix_name;

                hhi.AppendChild(path);
                hhi.AppendChild(regex);
                hhi.AppendChild(prefix_name);

                rootElement.AppendChild(hhi);
            }
            handinXML.Save(m_handInPath);
        }

        public static void SavePrefixs() {
            XmlDocument handinXML = new XmlDocument();
            XmlElement rootElement = handinXML.CreateElement("prefixs");
            handinXML.AppendChild(rootElement);
            foreach (var item in listPrefixes) {
                XmlElement hhi = handinXML.CreateElement("prefix");
                hhi.SetAttribute("name", item.name);

                XmlElement start = handinXML.CreateElement("start_id");
                start.InnerText = item.start.ToString();
                XmlElement end = handinXML.CreateElement("end_id");
                end.InnerText = item.end.ToString();

                hhi.AppendChild(start);
                hhi.AppendChild(end);

                rootElement.AppendChild(hhi);
            }
            handinXML.Save(m_prefixPath);
        }

        public static void SaveLog(string log) {
            XmlDocument logXML = new XmlDocument();
            XmlElement rootElement = logXML.CreateElement("logs");
            logXML.AppendChild(rootElement);
            rootElement.InnerText = log;

            logXML.Save(m_logPath + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + GetRandomSeed().ToString() + ".xml");
        }
        static int GetRandomSeed() {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
        public static List<string> FindFile(string sSourcePath) {
            List<String> list = new List<string>();
            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            foreach (FileInfo NextFile in thefileInfo)  //遍历文件
                list.Add(NextFile.Name);
            //遍历子文件夹
            //DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            //foreach (DirectoryInfo NextFolder in dirInfo) {
            //    //list.Add(NextFolder.ToString());
            //    FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);
            //    foreach (FileInfo NextFile in fileInfo)  //遍历文件
            //        list.Add(NextFile.FullName);
            //}
            return list;
        }

        public static List<string> FindFolders(string sSourcePath) {
            List<String> list = new List<string>();
            //遍历文件夹
            DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
            DirectoryInfo[] dirInfo = theFolder.GetDirectories();
            foreach (DirectoryInfo NextFolder in dirInfo) {
                list.Add(NextFolder.ToString());
                //FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);
                //foreach (FileInfo NextFile in fileInfo)  //遍历文件
                    //list.Add(NextFile.FullName);
            }
            return list;
        }
        }
    }
