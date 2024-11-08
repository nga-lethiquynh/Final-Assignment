namespace ShoeStore.Shared.ViewModels
{
    public class ProductDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}