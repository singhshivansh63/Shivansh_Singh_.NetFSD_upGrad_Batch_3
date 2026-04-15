namespace OrderService.Models
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
