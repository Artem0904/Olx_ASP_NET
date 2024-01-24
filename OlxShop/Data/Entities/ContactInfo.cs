namespace OlxShop.Data.Entities
{
    public class ContactInfo
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? WebSiteUrl { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
