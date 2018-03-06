using SmartShop.Inventory;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductListModel
    {
        private ProductManagementService _productManagementService;
        public ProductListModel()
        {
            _productManagementService = new ProductManagementService();
        }
        public object GetProductJsonData(DataTablesAjaxRequestModel model)
        {
            // All Post Data
            string[] columnOrder = { null, "Name", "Price", null, null, null };
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();

            int recordsTotal = 0;
            int recordsFiltered = 0;
            List<Product> records = _productManagementService.GetPagedProducts(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);

            int serial = (index * length) + 1;
            var dataSet = (
                    from record in records
                    select new string[]
                    {       serial++.ToString(),
                            record.Name.ToString(),
                            record.Price.ToString(),
                            record.CreatedAt.ToShortDateString(),
                            record.ID.ToString()
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