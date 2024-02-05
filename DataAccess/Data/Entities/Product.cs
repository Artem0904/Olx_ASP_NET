using System.Reflection;

namespace DataAccess.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        //public string Category { get; set; }

        public int CategoryId { get; set; }
        //public int? UserId { get; set; }

        public Category Category { get; set; }
        //public User? User { get; set; }
    }
}