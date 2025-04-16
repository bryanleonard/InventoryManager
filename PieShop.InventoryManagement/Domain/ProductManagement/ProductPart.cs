namespace PieShop.InventoryManagement;

public partial class Product
{
	private string CreateSimpleProdutRepresentation() {
		return $"Product {id} ({name})";
	}

	private void UpdateLowStock() {
	if (AmountInStock < 10) {
		isBelowStockThreshold = true;
	}
}
	
