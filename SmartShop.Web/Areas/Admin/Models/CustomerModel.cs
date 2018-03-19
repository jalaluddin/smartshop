using SmartShop.Foundation;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class CustomerModel
    {
        private CustomerManagementService _customerManagementService;
        public CustomerModel()
        {
            _customerManagementService = new CustomerManagementService();
        }
        public object GetCustomerJsonData(DataTablesAjaxRequestModel model)
        {

            // All Post Data
            string[] columnOrder = { null, "Name", null, null, "CreatedAt", null };
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();

            int recordsTotal = 0;
            int recordsFiltered = 0;
            List<Customer> records = _customerManagementService.GetPagedCustomerList(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);

            int serial = model.GetSerialNumber();
            var dataSet = (
                    from record in records
                    select new string[]
                    {
                        serial++.ToString(),
                        record.UserName.ToString(),
                        record.Email.ToString(),
                    }
                );

            var jsonData = new
            {
                recordsTotal = recordsTotal,
                recordsFiltered = recordsFiltered,
                data = dataSet
            };

            return jsonData;
        }
    }
}