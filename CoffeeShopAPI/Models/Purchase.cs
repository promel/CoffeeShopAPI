namespace CoffeeShopAPI.Models
{
	public class Purchase
	{
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }

        public int? UserId { get; set; }
        private User? User { get; set; }
    }
}