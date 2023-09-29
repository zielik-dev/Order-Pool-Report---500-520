using Order_Pool_Report___500___520.Infrastructure;
using System.Xml;

namespace Order_Pool_Report___500___520.RemoteConfigurations.EcoSystemServerConfig
{
    public class DbConnectionLogsTest : ConnectionStrings
    {
        public static string Read()
        {
            XmlDocument xml = new();
            xml.Load(ecoSystemDbConnection);

            XmlNodeList xmlNodeList = xml.SelectNodes("/EcoSystemDbConfig/Test/Database/VmReportingLogsDatabaseMichal");
            string str = xmlNodeList[0].InnerText;

            return str;
        }
    }
}