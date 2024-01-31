using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ContactInfoDto
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string? WebSiteUrl { get; set; }
        public int CityId { get; set; }
        public int UserId { get; set; }
        public string CityName { get; set; }
        public string UserName { get; set; }
    }
}
