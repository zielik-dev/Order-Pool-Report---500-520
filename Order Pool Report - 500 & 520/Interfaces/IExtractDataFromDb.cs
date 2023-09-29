using Order_Pool_Report___500___520.Models.Queries;

namespace Order_Pool_Report___500___520.Interfaces
{
    public interface IExtractDataFromDb
    {
        public List<RpOracleDbDataExtractModel> GetList();
    }
}
