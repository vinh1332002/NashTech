namespace assignment2.DTOs.Products
{
    public class AddProductResponse
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Manufacture { get; set; }

        public int CategoryId { get; set; }
    }
}