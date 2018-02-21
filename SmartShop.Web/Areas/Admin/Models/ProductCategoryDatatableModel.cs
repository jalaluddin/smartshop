using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartShop.Web.Models;
using SmartShop.Inventory;
using SmartShop.Data;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductCategoryDatatableModel
    {
        public int start { get; set; }
        public int length { get; set; }
        public int draw { get; set; }
        public string Search { get; set; }

        internal object GetProductCategoryJsonData(ProductCategoryDatatableModel dataTablesModel)
        {
            ProductManagementContext db = new ProductManagementContext();

            int start = dataTablesModel.start;
            int length = dataTablesModel.length;
            int draw = dataTablesModel.draw;

            int totalRecords = 0;
            int totalDisplayableRecords = 0;

            //*************************************
            ICollection<SortElement> sortItems =new DataTablesAjaxRequestModel().
                 GetSortElements(
                     new string[] {
                               "SL","Category Name","IsActive","Parent Category"
                    });

             // Fetching search
             string searchText = new DataTablesAjaxRequestModel().GetSearchText();

             //int totalRecords = 0;
             //int totalDisplayableRecords = 0;

             // Fetching sort
             string order = null;
             if (sortItems.Count > 0)
             {
                 order = string.Format("{0} {1}", sortItems.First<SortElement>().ColumnName, sortItems.First<SortElement>().Order.ToString());
             }
             else
             {
                 order = "CodeName ASC";
             }

            //**************************************
            List<ProductCategory> records = new ProductCategoryManagementService().GetResult(start,length,searchText,order/*, out totalRecords, out totalDisplayableRecords*/);


           // List<ProductCategory> records = _codingProblemFacade.GetArchiveProblems(pageIndex, pageSize, searchText, category, difficulty, problemID, title, order, out totalRecords, out totalDisplayableRecords);
            // Preparing Json for return
            int sl = start + 1;
            var data = (
                    from record in records
                    select new string[]
                    {       sl++.ToString(),
                            record.Name.ToString(),
                            record.IsActive.ToString(),
                            record.Name.ToString()
                    }
                );

            var jsonData = new
            {
                recordsTotal = new ProductCategoryManagementService().GetCount(),
                //recordsFiltered = records.Count(),
                data = data.ToArray()
            };
            return jsonData;
        }
    }
    
}