namespace Order_Pool_Report___500___520.Infrastructure
{
    public class ConnectionStrings
    {
        public static string ecoSystemGeneralConfig = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Config\EcoSystemGeneralConfig.xml";
        public static string ecoSystemDbConnection = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Config\EcoSystemDatabaseConfig.xml";
        public static string ecoSystemEmailDistributionConfig = @"\\XXX\LocalData$\XXXn\.NET Core Solution - Production Env\.Config\EcoSystemEmailDistributionConfig.xml";
        public static string sftpB2Bconfig = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Config\RedPrairie.config.xml";
        public static string smtpConfigFile = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Config\Gxo.smtp.server.config.xml";

        public static string archiveDir = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Archive\Order Pool Report - 500 & 520\";
        public static string queryFile = "Order_Pool_500_520_Query.sql";

        public static string srcTemplateDir = @"\\XXX\LocalData$\XXX\.NET Core Solution - Production Env\.Templates\";
        public static string srcTemplateFile = "Order Pool Report - 500 & 520.xlsm";
        public static string srcUnPlanned = "UnPlanned";
        public static string srcPlanned = "Planned";

        public static string logTitle = "Order Pool Report - 500 & 520";
    }
}
