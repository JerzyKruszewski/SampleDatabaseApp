using SampleDatabaseApp.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabaseApp.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<ICollection<Order>> GetAll();

        public Task<Order> Get(int id);

        public Task<Order> Add(Customer customer, Product product, int quantity);

        public Task<Order> Update(int id, Product product, int quantity);

        public Task Delete(int id);
    }
}
