using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;
using System.Globalization;
namespace DataTablesPagingDemo.Helper
{
    public class DataTablesReturned
    {
        public static object PageResponse(DataTablesSent pageRequest, Page<Product> report)
        {
            return new
            {
                draw = pageRequest.Draw,
                recordsTotal = report.TotalItems,
                recordsFiltered = report.TotalItems,
                data = (from i in report.Items
                          select i).ToList()
            };
        }
    }
    
    public class DataTablesSent
    {
        public int Draw { get; set; }
        public List<DataTablesColumn> Columns { get; set; }
        public List<DataTablesOrder> Order { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DataTablesSearch Search { get; set; }

        public class DataTablesColumn
        {
            public string Data { get; set; }
            public string Name { get; set; }
            public bool Searchable { get; set; }
            public bool Orderable { get; set; }
            public DataTablesSearch Search { get; set; }
        }
        public class DataTablesSearch
        {
            public string Value { get; set; }
            public bool Regex { get; set; }
        }
        public class DataTablesOrder
        {
            public int Column { get; set; }
            public string Dir { get; set; }
        }
        
    }
    
}