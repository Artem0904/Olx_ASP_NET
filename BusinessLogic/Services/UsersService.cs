using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BusinessLogic.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;

        public UsersService(IMapper mapper, ShopDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public IEnumerable<User> Get(IEnumerable<string> ids)
        {
            return context.Users
                .Where(x => ids.Contains(x.Id))
                .ToList();
        }

        public User? Get(string id)
        {
            var item = context.Users.Find(id);
            if (item == null) return null;

            return item;
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }
    }
}
