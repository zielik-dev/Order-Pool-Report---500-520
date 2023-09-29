using Order_Pool_Report___500___520.Interfaces;
using Order_Pool_Report___500___520.RemoteConfigurations.EcoSystemServerConfig;

namespace Order_Pool_Report___500___520.Infrastructure.Files
{
    public   class SqlQueryRead : ConnectionStrings, ISqlQueryRead
    {
        private static SqlQueryRead sqlQueryRead;
        private readonly string sqlQueriesDir;

        public SqlQueryRead()
        {
            sqlQueriesDir = SqlQueriesDir.Read();
        }

        public static SqlQueryRead Instance
        {
            get
            {
                if (sqlQueryRead == null)
                    sqlQueryRead = new SqlQueryRead();
                return sqlQueryRead;
            }
        }

        public string RpDbQueryRead()
        {
            string fullPath = Path.Combine(sqlQueriesDir, queryFile);

            var dir = File.ReadAllText(fullPath);

            return dir;
        }
    }
}