using SmartShop.Data;
using SmartShop.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class Sample
    {
        internal object GetProblemArchiveJson(DataTablesAjaxRequestModel dataTablesModel/*, string category, CodingProblemDifficulty? difficulty, string title, int? problemID*/)
        {

            try
            {
                // Fetching paging
                int pageIndex = dataTablesModel.GetPageIndex();
                int pageSize = dataTablesModel.GetPageSize();

                ICollection<SortElement> sortItems = dataTablesModel.
                    GetSortElements(
                    new string[] {
                              "CodeName",
                                  "Name",
                            "Difficulty",
                            "TotalSolve"
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
                {
                    order = "CodeName ASC";
                }
                    

                //Service Call
                // List<ProductCategory> records = _codingProblemFacade.GetArchiveProblems(pageIndex, pageSize, searchText, category, difficulty, problemID, title, order, out totalRecords, out totalDisplayableRecords);
                // _codingProblems = CodingProblems;

                //*****************************************
                ProductManagementContext db = new ProductManagementContext();
                List<ProductCategory> records = db.ProductCategory.OrderBy(u => u.ID).Skip(1).Take(1).ToList();
                //*****************************************

                // Preparing Json for return
                var jsonData = new
                {
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalDisplayableRecords,
                    aaData = (
                        from record in records
                        select new string[]
                        {
                           //sl++.ToString(),
                            record.ID.ToString(),
                            record.Name.ToString(),
                            record.IsActive.ToString(),
                            record.Name.ToString()
                        }
                    ).ToArray()
                };

                return jsonData;
            }
            catch (Exception ex)
            {
                /*_logHelperFactory.Create().WriteLog(LogType.HandledLog, this.GetType().Name,
                    "GetReviewProblemJson", ex, "Failed to get review problem list");*/

                return DataTablesAjaxRequestModel.EmptyResult;
            }
        }
    }
}