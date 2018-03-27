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
        public List<Product> Products { get; private set; }
        public ProductListModel()
        {
            _productManagementService = new ProductManagementService();
        }
        public object GetProductJsonData(DataTablesAjaxRequestModel model)
        {
            // All Post Data
            string[] columnOrder = { null, "Name", null, null,  null, null, null, null, null };
            int index = model.GetPageIndex();
            int length = model.GetPageSize();
            string searchValue = model.GetSearchText();
            string sortColumnName = model.GetSortColumnName(columnOrder);
            string sortDirection = model.GetSortDirection();

            int recordsTotal = 0;
            int recordsFiltered = 0;
            List<Product> records = _productManagementService.GetPagedProducts(index, length, searchValue,
                sortColumnName, sortDirection, out recordsTotal, out recordsFiltered);
            
            int serial = model.GetSerialNumber();
            var dataSet = (
                    from record in records
                    select new string[]
                    {
                        serial++.ToString(),
                        record.Name.ToString(),
                        (record.ProductCategory != null ? record.ProductCategory.Name.ToString() : "-" ),
                        record.Price.ToString(),
                        record.SpecialPrice.ToString(),
                        record.Quantity.ToString(),
                        (record.ProductImages != null ? record.ProductImages.Where(x => x.IsFeaturedImage).First().ImageUrl.ToString() : "-" ),
                        record.IsNew.ToString(),
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