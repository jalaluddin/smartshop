using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class CustomerManagementUnitOfWork
    {
        private CustomerManagementContext _context;
        public CustomerRepository CustomerRepository { get; set; }

        public CustomerManagementUnitOfWork(CustomerManagementContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
