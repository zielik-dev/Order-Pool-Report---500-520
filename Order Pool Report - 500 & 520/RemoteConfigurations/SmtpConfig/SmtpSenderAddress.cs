using Order_Pool_Report___500___520.Infrastructure;
using System.Xml;

namespace Order_Pool_Report___500___520.RemoteConfigurations.SmtpConfig
{
    public class SmtpSenderAddress : ConnectionStrings
    {
        public static string Read()
        {
            XmlDocument xml = new();
            xml.Load(smtpConfigFile);

            XmlNodeList xmlNodeList = xml.SelectNodes("GxoSmtpServerConfiguration/Sender");
            string str = xmlNodeList[0].InnerText;

            return str;
        }
    }
}