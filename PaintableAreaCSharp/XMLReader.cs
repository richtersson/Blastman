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
            XmlNode node = doc.DocumentElement.SelectSingleNode("/Settings/Server");
            Ip = node.Attributes["IP"]?.InnerText;
            DatabaseUserName = node.Attributes["DatabaseUserName"]?.InnerText;
            P_APV_KOD=node.Attributes["P_APV_KOD"]?.InnerText;
            P_UZI_KARTA_ID= node.Attributes["P_UZI_KARTA_ID"]?.InnerText;

           
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
