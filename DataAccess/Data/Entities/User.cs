using DataAccess.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Data.Entities
{
    public class User : IdentityUser
    {
        public DateTime Birthdate { get; set; }
        public DateTime Registerdate { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
