using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Foundation
{
    public class CustomerManagementService
    {
        private CustomerManagementContext _customerManagementContext;
        private CustomerManagementUnitOfWork _customerManagementUnit;
        public CustomerManagementService()
        {
            _customerManagementContext = new CustomerManagementContext();
            _customerManagementUnit = new CustomerManagementUnitOfWork(_customerManagementContext);
        }
        public List<Customer> GetPagedCustomerList(int index, int length, string searchValue,
            string sortColumnName, string sortDirection, out int recordsTotal, out int recordsFiltered)
        {
            recordsTotal = 0;
            recordsFiltered = 0;

            return _customerManagementUnit.CustomerRepository.GetDynamic(out recordsTotal, out recordsFiltered,
                x => x.Email.Contains(searchValue), sortColumnName + " " + sortDirection, "", index, length).ToList();
        }
    }
}
