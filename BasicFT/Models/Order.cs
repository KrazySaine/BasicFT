namespace FoodOrderingApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<FoodItem> OrderedItems { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerName { get; set; }
    }
}
