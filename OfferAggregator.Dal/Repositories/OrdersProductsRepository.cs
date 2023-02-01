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

        public List<FullOrderDto> GetAllProductsInOrderByOrderId(int orderId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<FullOrderDto> result = new List<FullOrderDto>();
                sqlCnctn.Open();
                sqlCnctn.Query<FullOrderDto, ProductWithCountDto, FullOrderDto>(
                    StoredProcedures.GetAllProductsInOrderByOrderId,
                    (fullOrder, productIdWithCount) =>
                    {
                        FullOrderDto crnt = null;

                        foreach (var o in result)
                        {
                            if (o.OrderId == fullOrder.OrderId)
                            {
                                crnt = o;
                            }
                        }

                        if (crnt is null)
                        {
                            crnt = fullOrder;
                            result.Add(crnt);
                            crnt.ProductWithCount = new List<ProductWithCountDto>();
                        }

                        crnt.ProductWithCount.Add(productIdWithCount);

                        return fullOrder;
                    },
                    new { orderId},
                    splitOn: "ProductId",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
