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
    public class ProductService : IProductService
    {
        private readonly SampleDatabaseContext _context;

        public ProductService()
        {
            _context = SampleDatabaseContext.GetSampleDatabaseContext();
        }

        public async Task<Product> Get(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> Add(string name)
        {
            Product product = new Product()
            {
                Id = default(int),
                ProductName = name
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> Update(int id, string name)
        {
            Product product = await Get(id);

            if (product is null)
            {
                return null;
            }

            product.ProductName = name;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task Delete(int id)
        {
            Product product = await Get(id);

            if (product is null)
            {
                return;
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
