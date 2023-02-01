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

        public FullOrderDto GetAllProductsInOrderByOrderId(int orderId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                FullOrderDto result = null;
                sqlCnctn.Open();
                sqlCnctn.Query<FullOrderDto, ManagerDto, ClientsDto, ProductWithCountDto, FullOrderDto>(
                    StoredProcedures.GetAllProductsInOrderByOrderId,
                    (fullOrder, manager, client, productIdWithCount) =>
                    {
                        if (result is null)
                        {
                            result = fullOrder;
                            result.Manager = manager;
                            result.Client = client;
                            result.ProductWithCount = new List<ProductWithCountDto>();
                        }
                        result.ProductWithCount.Add(productIdWithCount);

                        return fullOrder;
                    },
                    new { orderId },
                    splitOn: "Id, ProductId",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        //public bool UpdateCountProductInOrdersProducts(OrdersProductsDto ordersProducts)
        //{
        //    using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
        //    {

        //    }
        //}
    }
}
