using SmartShop.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace SmartShop.Web.Models
{
    public class DataTablesAjaxRequestModel
    {

        public int iDisplayStart { get; set;}
        public int iDisplayLength { get; set;}
        public int iSortingCols { get; set; }
        public static object EmptyResult
        {
            get
            {
                return new
                {
                    iTotalRecords = 0,
                    iTotalDisplayRecords = 0,
                    aaData = (new string[] { }).ToArray()
                };
            }
        }

        public ICollection<SortElement> GetSortElements(string[] columnNames)
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
        }

        public string GetSortText(string[] columnNames)
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
        }

        public string GetSearchText()
        {
            string searchText = HttpContext.Current.Request["sSearch"];
            return searchText;
        }

        public int GetPageIndex()
        {
            if (iDisplayLength > 0)
                return (iDisplayStart / iDisplayLength) + 1;
            else
                return 1;
        }

        public int GetPageSize()
        {
            if (iDisplayLength == 0)
                return 10;
            else
                return iDisplayLength;
        }
    }
}