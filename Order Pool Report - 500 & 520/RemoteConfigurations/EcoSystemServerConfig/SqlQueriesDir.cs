using Order_Pool_Report___500___520.Infrastructure;
using System.Xml;

namespace Order_Pool_Report___500___520.RemoteConfigurations.EcoSystemServerConfig
{
    public class SqlQueriesDir : ConnectionStrings
    {
        public static string Read()
        {
            XmlDocument xml = new();
            xml.Load(ecoSystemGeneralConfig);

            XmlNodeList xmlNodeList = xml.SelectNodes("/EcoSystemServerConfiguration/Directories/SqlQueriesDir");
            string str = xmlNodeList[0].InnerText;

            return str;
        }
    }
}
