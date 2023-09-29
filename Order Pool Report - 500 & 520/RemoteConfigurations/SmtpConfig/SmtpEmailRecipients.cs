using Order_Pool_Report___500___520.Infrastructure;
using System.Xml;

namespace Order_Pool_Report___500___520.RemoteConfigurations.SmtpConfig
{
    public class SmtpEmailRecipients : ConnectionStrings
    {
        public static string Read()
        {
            XmlDocument xml = new();
            xml.Load(ecoSystemEmailDistributionConfig);

            XmlNodeList xmlNodeList = xml.SelectNodes("AppsEmailDistribution/NetExpOrderPool");
            string str = xmlNodeList[0].InnerText;

            return str;
        }
    }
}
