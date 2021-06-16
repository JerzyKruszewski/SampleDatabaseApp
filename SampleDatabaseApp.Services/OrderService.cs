using Microsoft.EntityFrameworkCore;
using SampleDatabaseApp.Model;
using SampleDatabaseApp.Model.Objects;
using SampleDatabaseApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabaseApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly SampleDatabaseContext _context;

        public OrderService()
        {
            _context = SampleDatabaseContext.GetSampleDatabaseContext();
        }

        public async Task<Order> Get(int id)
        {
            return await _context.Orders.SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> Add(Customer customer, Product product, int quantity)
        {
            Order order = new Order()
            {
                Id = default(int),
                CustomerId = customer.Id,
                ProductId = product.Id,
                Quantity = quantity,
                OrderDate = DateTime.UtcNow
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> Update(int id, Product product, int quantity)
        {
            Order order = await Get(id);

            if (order is null)
            {
                return null;
            }

            order.ProductId = product.Id;
            order.Quantity = quantity;

            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task Delete(int id)
        {
            Order order = await Get(id);

            if (order is null)
            {
                return;
            }

            _context.Orders.Remove(order);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }
    }
}
