using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal
{
    public class OrderRepository
    {
        public int AddOrder(OrderDto order)
        {
            using (var SqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                SqlConnect.Open();
                return SqlConnect.QuerySingle<int>(StoredProcedures.AddOrder,
                    new
                    {
                        order.DateCreate,
                        order.ComplitionDate,
                        order.ManagerId,
                        order.ClientId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<OrderDto> GetAllOrdersByIdManager(int managerId)
        {
            using (var SqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                var result = new List<OrderDto>();

                SqlConnect.Open();
                SqlConnect.Query<OrderDto, ClientsDto, OrderDto>(
                    StoredProcedures.GetAllOrdersByIdManager,
                    (order, client) =>
                    {
                        OrderDto crnt = null;

                        foreach (var o in result)
                        {
                            if (o.Id == order.Id)
                            {
                                crnt = o;
                            }
                        }

                        if (crnt is null)
                        {
                            crnt = order;
                            result.Add(crnt);
                        }


                        crnt.Client = client;

                        return order;
                    },
                    new { managerId },
                    splitOn: "Name",
                    commandType: CommandType.StoredProcedure) ;

                return result;
            }
        }
    }
}
