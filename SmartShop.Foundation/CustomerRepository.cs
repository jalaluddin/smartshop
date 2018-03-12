using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class CustomerRepository: Repository<Customer>
    {
        private CustomerManagementContext _context;
        public CustomerRepository(CustomerManagementContext context) :base(context)
        {
            _context = context;
        }
    }
}
