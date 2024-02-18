﻿using Microsoft.AspNetCore.Http;

namespace BusinessLogic.DTOs
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public bool InStock { get; set; }
        public string? CityName { get; set; }
        public int CityId { get; set; }
        public string? UserName { get; set; }
        public string UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}