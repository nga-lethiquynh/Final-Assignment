using System.Collections.Generic;

namespace ShoeStore.API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}