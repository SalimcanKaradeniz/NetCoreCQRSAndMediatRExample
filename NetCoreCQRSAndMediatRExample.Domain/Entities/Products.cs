namespace NetCoreCQRSAndMediatRExample.Domain.Entities
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StockCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal InstallmentPrice { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime CreateTime { get; set; }
    }
}