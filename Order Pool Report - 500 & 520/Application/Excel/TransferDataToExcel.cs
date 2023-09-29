using Microsoft.Office.Interop.Excel;
using Order_Pool_Report___500___520.Models.Commands;

namespace Order_Pool_Report___500___520.Domain.Excel
{
    public class TransferDataToExcel
    {
        public static void InsertToWorksheet(List<ExcelModel> finalListForExce, Worksheet plannedWs, Worksheet unPlannedWs)
        {
            foreach (var item in finalListForExce)
            {
                Console.WriteLine(item.OrderId + " " + item.Status + " " + item.WorkGroup);

                if (item.Status == "Released")
                {
                    int nextRow = unPlannedWs.UsedRange.Rows.Count + 1;
                    unPlannedWs.Cells[nextRow, 1] = item.SiteId;
                    unPlannedWs.Cells[nextRow, 2] = item.OrderId;
                    unPlannedWs.Cells[nextRow, 3] = item.DeliveryDate;
                    unPlannedWs.Cells[nextRow, 4] = item.Status;
                    unPlannedWs.Cells[nextRow, 5] = item.Consignment;
                    unPlannedWs.Cells[nextRow, 6] = item.CreationDate;
                    unPlannedWs.Cells[nextRow, 7] = item.Town;
                    unPlannedWs.Cells[nextRow, 8] = item.PostCode;
                    unPlannedWs.Cells[nextRow, 9] = item.Name;
                    unPlannedWs.Cells[nextRow, 10] = item.Sku;
                    unPlannedWs.Cells[nextRow, 11] = item.QtyOrdered;
                    unPlannedWs.Cells[nextRow, 12] = item.PalletCount;
                    unPlannedWs.Cells[nextRow, 13] = item.TotalValue;
                    unPlannedWs.Cells[nextRow, 14] = item.WorkGroup;
                }
                if (item.Status == "Allocated" || item.Status == "Picked" || item.Status == "Packed" || item.Status == "Complete" || item.Status == "Hold")
                {
                    int nextRow = plannedWs.UsedRange.Rows.Count + 1;
                    plannedWs.Cells[nextRow, 1] = item.SiteId;
                    plannedWs.Cells[nextRow, 2] = item.OrderId;
                    plannedWs.Cells[nextRow, 3] = item.DeliveryDate;
                    plannedWs.Cells[nextRow, 4] = item.Status;
                    plannedWs.Cells[nextRow, 5] = item.Consignment;
                    plannedWs.Cells[nextRow, 6] = item.CreationDate;
                    plannedWs.Cells[nextRow, 7] = item.Town;
                    plannedWs.Cells[nextRow, 8] = item.PostCode;
                    plannedWs.Cells[nextRow, 9] = item.Name;
                    plannedWs.Cells[nextRow, 10] = item.Sku;
                    plannedWs.Cells[nextRow, 11] = item.QtyOrdered;
                    plannedWs.Cells[nextRow, 12] = item.PalletCount;
                    plannedWs.Cells[nextRow, 13] = item.TotalValue;
                    plannedWs.Cells[nextRow, 14] = item.WorkGroup;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}