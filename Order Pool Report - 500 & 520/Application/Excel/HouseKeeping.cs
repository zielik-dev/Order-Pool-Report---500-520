using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Order_Pool_Report___500___520.Domain.Excel
{
    public class HouseKeeping
    {
        public static void Clear(Worksheet plannedWs, Worksheet unPlannedWs)
        {
            Range rngPlanned = plannedWs.get_Range("A5", "N100000");
            rngPlanned.EntireRow.Delete(Type.Missing);

            Range rngUnPlanned = unPlannedWs.get_Range("A5", "N100000");
            rngUnPlanned.EntireRow.Delete(Type.Missing);
        }
    }
}