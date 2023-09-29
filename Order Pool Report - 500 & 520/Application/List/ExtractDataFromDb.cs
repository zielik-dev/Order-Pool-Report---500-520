using Dapper;
using Oracle.ManagedDataAccess.Client;
using Order_Pool_Report___500___520.Infrastructure.Files;
using Order_Pool_Report___500___520.Interfaces;
using Order_Pool_Report___500___520.Models.Queries;
using Order_Pool_Report___500___520.RemoteConfigurations.EcoSystemServerConfig;
using System.Data;

namespace Order_Pool_Report___500___520.Domain.List
{
    public class ExtractDataFromDb : IExtractDataFromDb
    {
        private static string oracleDbProdConnStr, sqlQuery;

        public ExtractDataFromDb()
        {
            oracleDbProdConnStr = RpOracleDbConnectionProd.Read();
            sqlQuery = SqlQueryRead.Instance.RpDbQueryRead();
        }

        protected IDbConnection GetProdConnection
        {
            get
            {
                var oracleConnection = new OracleConnection(oracleDbProdConnStr);
                oracleConnection.Open();
                return oracleConnection;
            }
        }

        public List<RpOracleDbDataExtractModel> GetList()
        {
            using (var dbConnection = GetProdConnection)
            {
                return dbConnection.Query<RpOracleDbDataExtractModel>(sqlQuery).ToList();
            }
        }
    }
}