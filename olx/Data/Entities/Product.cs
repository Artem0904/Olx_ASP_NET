using FluentValidation;
using System.Reflection;

namespace olx.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
		

		//public int CityId { get; set; }
		//public City City { get; set; }
		//public int UserId { get; set; }
		//public User User { get; set; }
	}
}