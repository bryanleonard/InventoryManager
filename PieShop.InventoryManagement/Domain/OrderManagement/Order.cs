namespace PieShop.InventoryManagement;

public class Order
{
	public int Id { get; set; }
	public DateTime OrderFulfilmentDate { get; private set; }	
	public List<OrderItem> OrderItems { get; };
	public bol Fulfilled { get; set;} = false;

	public Order() {
		Id = new Random().Next(9999999);
		int numberOfSeconds = new Random().Next(100);
		OrderFulfilmentDate = DateTime.Now.AddSeconds(numberOfSeconds);

		OrderItems = new List<OrderItem>();
	}

}
