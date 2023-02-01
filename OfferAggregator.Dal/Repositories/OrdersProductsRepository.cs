using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class OrdersProductsRepository
    {
        public bool AddOrdersProductsToOrdersProducts(OrdersProductsDto orderProduct)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.AddOrdersProductsToOrdersProducts,
                    new { orderProduct.OrderId, orderProduct.ProductId, orderProduct.CountProduct },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
