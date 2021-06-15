using SampleDatabaseApp.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDatabaseApp.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<Customer> Get(int id);

        public Task<Customer> Add(string firstName, string lastName);

        public Task<Customer> Update(int id, string firstName, string lastName);

        public Task Delete(int id);
    }
}
