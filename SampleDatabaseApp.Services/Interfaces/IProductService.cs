using SampleDatabaseApp.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabaseApp.Services.Interfaces
{
    public interface IProductService
    {
        public Task<ICollection<Product>> GetAll();

        public Task<Product> Get(int id);

        public Task<Product> Add(string name);

        public Task<Product> Update(int id, string name);

        public Task Delete(int id);
    }
}
