using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Dynamic;
using SmartShop.Data;
using System.Data.SqlClient;

namespace SmartShop.Web.Models
{
    public class DataTablesAjaxRequestModel
    {
        public int Start { get; set; }
        public int Length { get; set; }
        //public string value { get; set; }
        //public string SortColumnName { get; set; }
       // public string SortDirection { get; set; }

        /*string[] columnOrder = { null, "Name", null, null, "CreatedAt", null };
        int start = Convert.ToInt32(Request["start"]);
        int length = Convert.ToInt32(Request["length"]);
        string searchValue = Request["search[value]"];
        string sortColumnName = columnOrder[Convert.ToInt32(Request["order[0][column]"])];
        string sortDirection = Request["order[0][dir]"];*/

        /*public ICollection<SortElement> GetSortElements(string[] columnNames)
        {
            ICollection<SortElement> sortItems = new List<SortElement>();

            for (int i = 0; i < iSortingCols; i++)
            {
                int colIndex = 0;
                int.TryParse(HttpContext.Current.Request["iSortCol_" + i], out colIndex);
                if (HttpContext.Current.Request["bSortable_" + colIndex] == "true")
                {
                    sortItems.Add(new SortElement(columnNames[colIndex],
                        HttpContext.Current.Request["sSortDir_" + i] == "asc" ? SortOrder.Ascending : SortOrder.Descending));
                }
            }
            return sortItems;
        }*/

        /*public string GetSortText(string[] columnNames)
        {
            StringBuilder sortText = new StringBuilder();
            for (int i = 0; i < iSortingCols; i++)
            {
                int colIndex = 0;
                int.TryParse(HttpContext.Current.Request["iSortCol_" + i], out colIndex);
                if (HttpContext.Current.Request["bSortable_" + colIndex] == "true")
                {
                    sortText.Append(columnNames[colIndex]).Append(" ")
                        .Append(HttpContext.Current.Request["sSortDir_" + i]).Append(" ");
                }
            }
            return sortText.ToString();
        }*/

        public string GetSearchText()
        {
            string searchText = HttpContext.Current.Request["search[value]"];
            return searchText;
        }

        public string GetSortDirection()
        {
            string sortDirection = HttpContext.Current.Request["order[0][dir]"];
            return sortDirection;
        }

        public string GetSortColumnName(string [] columnOrder)
        {
            string sortColumnName = columnOrder[Convert.ToInt32(HttpContext.Current.Request["order[0][column]"])];
            return sortColumnName;
        }

        /*public int GetPageIndex()
        {
            if (Length > 0)
                return (Start / Length) + 1;
            else
                return 1;
        }*/

        /*public int GetPageSize()
        {
            if (Length == 0)
                return 10;
            else
                return Length;
        }*/
    }
}