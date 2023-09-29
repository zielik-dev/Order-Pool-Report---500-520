namespace Order_Pool_Report___500___520.Models.Commands
{
    public class ExcelModel
    {
        public string SiteId { get; set; }
        public string OrderId { get; set; }
        public string? DeliveryDate { get; set; }
        public string? Status { get; set; }
        public string? Consignment { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? Town { get; set; }
        public string? PostCode { get; set; }
        public string? Name { get; set; }
        public int? Sku { get; set; }
        public decimal? QtyOrdered { get; set; }
        public decimal? PalletCount { get; set; }
        public decimal? TotalValue { get; set; }
        public string? WorkGroup { get; set; }
    }
}