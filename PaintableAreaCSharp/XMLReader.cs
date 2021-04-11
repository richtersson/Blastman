using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Blastman
{
    public static class XMLReader
    {
        public static string Ip;
        public static string DatabaseUserName;
        public static string P_APV_KOD;
        public static string P_UZI_KARTA_ID;
        public static void ReadSetting(string XMLPath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(XMLPath);
            XmlNode node = doc.DocumentElement.SelectSingleNode("/Settings/Blastman");
            AddinGlobal.BlastmanModelFolder = node.Attributes["Folder"]?.InnerText;
            AddinGlobal.DatabasePath = node.Attributes["Database"]?.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/Settings/Limits");
            AddinGlobal.P1_Min = node.Attributes["P1_Min"]?.InnerText;
            AddinGlobal.P1_Max = node.Attributes["P1_Max"]?.InnerText;
            AddinGlobal.P2_Min = node.Attributes["P2_Min"]?.InnerText;
            AddinGlobal.P2_Max = node.Attributes["P2_Max"]?.InnerText;
            AddinGlobal.P3_Min = node.Attributes["P3_Min"]?.InnerText;
            AddinGlobal.P3_Max = node.Attributes["P3_Max"]?.InnerText;
            AddinGlobal.P4_Min = node.Attributes["P4_Min"]?.InnerText;
            AddinGlobal.P4_Max = node.Attributes["P4_Max"]?.InnerText;
            AddinGlobal.P5_Min = node.Attributes["P5_Min"]?.InnerText;
            AddinGlobal.P5_Max = node.Attributes["P5_Max"]?.InnerText;
            AddinGlobal.P6_Min = node.Attributes["P6_Min"]?.InnerText;
            AddinGlobal.P6_Max = node.Attributes["P6_Max"]?.InnerText;
            AddinGlobal.P7_Min = node.Attributes["P7_Min"]?.InnerText;
            AddinGlobal.P7_Max = node.Attributes["P7_Max"]?.InnerText;
            AddinGlobal.P8_Min = node.Attributes["P8_Min"]?.InnerText;
            AddinGlobal.P8_Max = node.Attributes["P8_Max"]?.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/Settings/Project");
            AddinGlobal.BlastmanProject = node.Attributes["Name"]?.InnerText;


        }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
    }
}
