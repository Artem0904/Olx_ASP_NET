using OlxShop.Data.Entities;

namespace OlxShop.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
        public int? ContactInfoId { get; set; }
        public ContactInfo? ContactInfo { get; set; }

    }
}
