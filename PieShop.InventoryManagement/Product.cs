namespace PieShop.InventoryManagement;

public class Product
{
	public Product(int id) : this(id, string.Empty) {
	}

	public Product(int id, string name) {
		Id = id;
		Name = name;
	}

	public Product(int id, string name, string? description, UnitType unitType, int maxAmountInStock) {
		Id = id;
		Name = name;
		Description = description;
		UnitType = unitType;
		maxItemsInStock = maxAmountInStock

		UpdateLowStock();
	}

	private readonly Logger _logger = new();

	private int id;
	private string name = string.Empty;
	private string? description;

	private int maxItemsInStock = 0;
	
	public int Id {
		get { return id; }
		set { id = value}
	}

	public string Name {
		get { return name; }
		set { name = value.Length> 50 ? value[..50] : value }
	}

	public string? Description {
		get { return description; }
		set {
			if (value == null) {
				description = string.Empty
			}
			else {
				description = value.Length > 250 ? value[..250] : value;
			}
		}
	}

	public UnitTtype UnitTtype { get; set; }
	public int AmountInStock { get; private set; }
	public bool IsBelowStockThreshold { get; private set;}

	public void UseProduct(int items) {
		if (items <= AmountInStock)	{
			//use the items
			AmountInStock -= items;

			UpdateLowStock();
			_logger.Log($"Amount in stock updated. Now {amountInStock} items in stocks.");
		}	
		else {
			_logger.Log($"Not enough items in stock for {CreateSimpleProdutRepresentation()}. {AmountInStock} avaiable but {items} requested.")
		}
	}

	public void IncreaseStock() {
		AmountInStock++;
	}

	public void IncreaseStock(int amount) {
		int newStock = AmountInStock + amount;

		if (newStock <= maxItemsInStock) {
			AmountInStock += amount;
		}
		else {
			AmountInStock = maxItemsInStock;
			_logger.Log($"{CreateSimpleProdutRepresentation} stock overflow. {newStock - AmountInStock} item(s) ordered that couldn't be stored.");
		}

		if (AmountInStock > 10) {
			IsBelowStockThreshold = false;
		}

	}

	public void IncreaseStock(int items = 1) {
		AmountInStock += items;
	}

	private void DecreaseStock(int items = 1, string reason) {
		if (items <= AmountInStock) {
			//decrease the stock
			AmountInStock -= items;
		}
		else {
			AmountInStock = 0;
		}

		UpdateLowStock()
		_logger.Log(reason);
	}

	private void UpdateLowStock() {
		if (AmountInStock < 10) {
			isBelowStockThreshold = true;
		}
	}

	private string DisplayDetailsShort() {
		return $"{id} {Name} \n{AmountInStock} items in stock"
	}

	private string DisplayDetailsFull() {
		// StringBuilder sb = new();
		// //ToDo: add price here 
		// sb.Append($"{id} {Name} \n{descriprtion}\n{AmountInStock} item(s) in stock");

		// if (isBelowStockThreshold) {
		// 	sb.Append("\n!! LOW STOCK !!");
		// }

		// return sb.ToString();
		DisplayDetailsFull("");
	}

	privage string DisplayDetailsFull(string extraDetails) {
StringBuilder sb = new();
		//ToDo: add price here 
		sb.Append($"{id} {Name} \n{descriprtion}\n{AmountInStock} item(s) in stock");
		sb.Append(extraDetails)

		if (isBelowStockThreshold) {
			sb.Append("\n!! LOW STOCK !!");
		}

		return sb.ToString();
	}

	private string CreateSimpleProdutRepresentation() {
		return $"Product {id} ({name})";
	}


	
}
