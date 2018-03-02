using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class Sample
    {
        internal object GetCategoryArchiveJson(DataTablesAjaxRequestModel dataTablesModel, string category, CodingProblemDifficulty? difficulty, string title, int? problemID)
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
                    order = "CodeName ASC";

                //Service Call
                List<CodingProblem> records = _codingProblemFacade.GetArchiveProblems(pageIndex, pageSize, searchText, category, difficulty, problemID, title, order, out totalRecords, out totalDisplayableRecords);
                _codingProblems = CodingProblems;

                // Preparing Json for return
                var jsonData = new
                {
                    iTotalRecords = totalRecords,
                    iTotalDisplayRecords = totalDisplayableRecords,
                    aaData = (
                        from record in records
                        select new string[]
                        {
                            string.Format("{0}-{1}", "DCP", record.CodeName.ToString("00")),
                            record.Name,
                            ((int)record.Difficulty).ToString(),
                            record.CalculateSuccessRate().ToString(),
                            record.TotalSolve.ToString(),
                            record.TotalSubmission.ToString(),
                            record.CodeName.ToString(),
                            SolveStatus[record.CodeName].ToString(),
                            uDebugStatus[record.CodeName].ToString()
                        }
                    ).ToArray()
                };

                return jsonData;
            }
            catch (Exception ex)
            {
                _logHelperFactory.Create().WriteLog(LogType.HandledLog, this.GetType().Name,
                    "GetReviewProblemJson", ex, "Failed to get review problem list");

                return DataTablesAjaxRequestModel.EmptyResult;
            }
        }
    }
}