namespace ShoeStore.Shared.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}