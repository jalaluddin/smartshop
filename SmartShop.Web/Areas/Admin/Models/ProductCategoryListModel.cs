using SmartShop.Inventory;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductCategoryListModel
    {
        private ProductCategoryManagementService _productCategoryManagementService;

        public List<ProductCategory> Categories { get; private set; }

        public ProductCategoryListModel()
        {
            _productCategoryManagementService = new ProductCategoryManagementService();
        }

        public object GetProductCategoryJson(DataTablesAjaxRequestModel model)
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
            List<ProductCategory> records = _productCategoryManagementService.GetPagedCategories(index, length, searchValue, 
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);

            int serial = (index * length) + 1;
            var dataSet = (
                    from record in records
                    select new string[]
                    {       serial++.ToString(),
                            record.Name.ToString(),
                            record.IsActive.ToString(),
                            (record.ParentCatgory != null ? record.ParentCatgory.Name.ToString() : "-" ),
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