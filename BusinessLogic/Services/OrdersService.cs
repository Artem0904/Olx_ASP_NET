using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly ShopDbContext context;
        private readonly ICartService cartService;

        public OrdersService(IMapper mapper, ShopDbContext context, ICartService cartService)
        {
            this.mapper = mapper;
            this.context = context;
            this.cartService = cartService;
        }

        public void Create(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDto> GetAllByUser(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
