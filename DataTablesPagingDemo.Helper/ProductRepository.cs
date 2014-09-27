using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
namespace DataTablesPagingDemo.Helper
{
    public class ProductRepository
    {
        private readonly Database _database = new Database("DataTablesPagingDemo");

        public Page<Product> GetCustomers(DataTablesSent pageRequest)
        {
            var query = Sql.Builder
                .Select("*")
                .From("Products");

            if (!string.IsNullOrEmpty(pageRequest.Search.Value))
            {
                var whereClause = string.Join(" OR ", GetSearchClause(pageRequest));

                if (!string.IsNullOrEmpty(whereClause))
                    query.Append("WHERE " + whereClause, "%" + pageRequest.Search.Value + "%");
            }

            var orderBy = string.Join(",", GetOrderByClause(pageRequest));

            if (!string.IsNullOrEmpty(orderBy))
            {
                query.Append("ORDER BY " + orderBy);
            }

            var startPage = (pageRequest.Length == 0) ? 1 : pageRequest.Start / pageRequest.Length + 1;

            return _database.Page<Product>(startPage, pageRequest.Length, query);
        }

        private static IEnumerable<string> GetSearchClause(DataTablesSent pageRequest)
        {
            foreach (var col in pageRequest.Columns)
            {
                if (col.Searchable)
                    yield return string.Format("{0} LIKE @0", col.Data);
            }
        }

        private static IEnumerable<string> GetOrderByClause(DataTablesSent pageRequest)
        {

            foreach (var order in pageRequest.Order)
            {
                yield return string.Format("{0} {1}", pageRequest.Columns[order.Column].Data, order.Dir);
            }
        }
    }
}
