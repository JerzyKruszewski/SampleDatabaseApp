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
    public class CustomerService : ICustomerService
    {
        private readonly SampleDatabaseContext _context = SampleDatabaseContext.GetSampleDatabaseContext();

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> Add(string firstName, string lastName)
        {
            Customer customer = new Customer()
            {
                Id = default(int),
                FirstName = firstName,
                LastName = lastName,
                Orders = new List<Order>()
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Update(int id, string firstName, string lastName)
        {
            Customer customer = await Get(id);

            customer.FirstName = firstName;
            customer.LastName = lastName;

            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task Delete(int id)
        {
            Customer customer = await Get(id);

            _context.Customers.Remove(customer);

            await _context.SaveChangesAsync();
        }
    }
}
