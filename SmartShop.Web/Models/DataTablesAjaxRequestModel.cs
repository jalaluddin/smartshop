using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartShop.Web.Models
{
    public class DataTablesAjaxRequestModel
    {
        public int Start { get; set; }
        public int Length { get; set; }

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

        public string GetSortColumnName(string[] columnOrder)
        {
            string sortColumnName = columnOrder[Convert.ToInt32(HttpContext.Current.Request["order[0][column]"])];
            if (string.IsNullOrWhiteSpace(sortColumnName))
                sortColumnName = "ID";
            return sortColumnName;
        }

        public int GetPageIndex()
        {
            if (Length > 0)
                return (Start / Length) + 1;
            else
                return 1;
        }

        public int GetPageSize()
        {
            if (Length == 0)
                return 10;
            else
                return Length;
        }

        public int GetSerialNumber()
        {
            return Start + 1;
        }
    }
}
 