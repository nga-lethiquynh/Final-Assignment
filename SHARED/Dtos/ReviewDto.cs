namespace ShoeStore.Shared.Dtos
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
    }
}