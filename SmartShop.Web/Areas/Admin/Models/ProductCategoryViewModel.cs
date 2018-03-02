using SmartShop.Data;
using SmartShop.Inventory;
using SmartShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Areas.Admin.Models
{
    public class ProductCategoryViewModel
    {
        private ProductCategoryManagementService _productCategoryManagementService;

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Guid ParentCategoryId { get; set; }


        public ProductCategoryViewModel()
        {
            _productCategoryManagementService = new ProductCategoryManagementService();
        }

        internal object GetProductCategoryJson(DataTablesAjaxRequestModel dataTablesModel, Guid categoryId )
        {

            try
            {
                // Fetching paging
                int pageIndex = dataTablesModel.GetPageIndex();
                int pageSize = dataTablesModel.GetPageSize();

                ICollection<SortElement> sortItems = dataTablesModel.
                    GetSortElements(
                    new string[] {
                                "ID",
                                "Name",
                                "ParentId",
                                "IsActive"
                   });

                // Fetching search
                string searchText = dataTablesModel.GetSearchText();

                int totalRecords = 0;
                int totalDisplayableRecords = 0;

                // Fetching sort
                string order = null;
                if (sortItems.Count > 0)
                {
                    order = string.Format("{0} {1}", sortItems.First<SortElement>().ColumnName, sortItems.First<SortElement>().Order.ToString());
                }
                else
                    order = "ID ASC";

                //Service Call
                List<ProductCategory> records = _productCategoryManagementService.GetCategories(out totalRecords, out totalDisplayableRecords, null, null, pageIndex, pageSize).ToList<ProductCategory>();
                

                // Preparing Json for return
                var jsonData = new
                {
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalDisplayableRecords,
                    aaData = (
                        from record in records
                        select new string[]
                        {
                            record.ID.ToString(),
                            record.Name,
                            record.ParentCatgory.ID.ToString(),
                            record.IsActive.ToString()
                        }
                    ).ToArray()
                };

                return jsonData;
            }
            catch (Exception ex)
            {
                //_logHelperFactory.Create().WriteLog(LogType.HandledLog, this.GetType().Name,
                //    "GetReviewProblemJson", ex, "Failed to get review problem list");

                return DataTablesAjaxRequestModel.EmptyResult;
            }
        }
    }
}