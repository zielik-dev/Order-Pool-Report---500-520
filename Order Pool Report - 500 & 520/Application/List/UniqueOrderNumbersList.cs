using Order_Pool_Report___500___520.Models.Queries;

namespace Order_Pool_Report___500___520.Domain.List
{
    public class UniqueOrderNumbersList
    {
        public static HashSet<string> GetUniqueOrderNumbers(List<RpOracleDbDataExtractModel> dbRawList)
        {
            HashSet<string> list = new();

            foreach(var item in dbRawList)
            {
                list.Add(item.OrderId);
            }

            return list;
        }
    }
}