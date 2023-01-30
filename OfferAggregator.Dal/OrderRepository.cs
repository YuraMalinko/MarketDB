using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Options;
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
                    commandType:CommandType.StoredProcedure);
            }
        }
    }
}
