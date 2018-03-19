using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class CustomerManagementUnitOfWork : UnitOfWork
    {
        public CustomerRepository CustomerRepository { get; set; }

        public CustomerManagementUnitOfWork(CustomerManagementContext context) : base(context)
        {
            CustomerRepository = new CustomerRepository(context);
        }
    }
}
