namespace HMS_SAAS.DataLayer.Models
{
    public class OrdersResponse
    {
        public int OrderId { get; set; }
        public string ItemId { get; set; }
        public string ItemName {  get; set; }
        public int Quantity {  get; set; }
        public DateTime? CreatedAt {  get; set; }
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
    public class OrdersRequest
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
