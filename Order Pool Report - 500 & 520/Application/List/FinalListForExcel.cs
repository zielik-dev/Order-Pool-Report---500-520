using Order_Pool_Report___500___520.Models.Commands;
using Order_Pool_Report___500___520.Models.Queries;
using System.Globalization;

namespace Order_Pool_Report___500___520.Domain.List
{
    public class FinalListForExcel
    {
        private const decimal PalletDefaultValue = 0.00005m;

        public static List<ExcelModel> BuildFinalList(List<RpOracleDbDataExtractModel> dbRawList, HashSet<string> uniqueOrderList)
        {
            List<ExcelModel> ListForExcel = new();

            foreach (var orderId in uniqueOrderList)
            {
                string siteId = null;
                string deliveryDate = null;
                string status = null;
                string consignment = null;
                string creationDate = null;
                string town = null;
                string postCode = null;
                string name = null;
                int skus = 0;
                decimal qtyOrdered = 0;
                decimal palletCount = 0;
                decimal totalValue = 0;
                string workGroup = null;

                foreach (var item2 in dbRawList)
                {
                    if (orderId == item2.OrderId)
                    {
                        siteId = item2.SiteId;
                        deliveryDate = item2.DeliveryDate;
                        status = item2.Status;
                        consignment = item2.Consignment;
                        creationDate = item2.CreationDate;
                        town = item2.Town;
                        postCode = item2.PostCode;
                        name = item2.Name;
                        skus++;

                        //if value exists, parse and increment counter by parsed value.
                        if (!string.IsNullOrEmpty(item2.QtyOrdered))
                        {
                            qtyOrdered += decimal.Parse(item2.QtyOrdered);
                        }

                        //if value exists and is not null, parse and increment counter by parsed value.
                        if (!(string.IsNullOrEmpty(item2.PalletCount) || item2.PalletCount == "null"))
                        {
                            decimal parsedValue;
                            if (decimal.TryParse(item2.PalletCount, out parsedValue))
                            {
                                palletCount += parsedValue;
                            }
                            else
                            {
                                palletCount += PalletDefaultValue;
                            }
                        }

                        if (!string.IsNullOrEmpty(item2.TotalValue))
                        {
                            totalValue += decimal.Parse(item2.TotalValue);
                        }

                        workGroup = item2.WorkGroup;
                    }
                }

                ListForExcel.Add(new ExcelModel
                {
                    SiteId = siteId,
                    OrderId = orderId,
                    DeliveryDate = deliveryDate,
                    Status = status,
                    Consignment = consignment,
                    CreationDate = Convert.ToDateTime(creationDate, new CultureInfo("en-GB", true)),
                    Town = town,
                    PostCode = postCode,
                    Name = name,
                    Sku = skus,
                    QtyOrdered = qtyOrdered,
                    PalletCount = palletCount,
                    TotalValue = totalValue,
                    WorkGroup = workGroup,
                });
            }

            return ListForExcel;
        }
    }
}
