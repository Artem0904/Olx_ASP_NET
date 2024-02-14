using System; 
namespace BusinessLogic.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        public bool InStock { get; set; }
        public string ImageUrl { get; set; }
        public string? CategoryName { get; set; }
        public string? CityName { get; set; }
        public int CityId { get; set; }
        //public string? CountryName { get; set; }
        //public int Country { get; set; }
    }
}  
