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

        public int UpdateOrder(OrderDto order)
        {
            using (var SqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                SqlConnect.Open();

                return SqlConnect.Execute(
                    StoredProcedures.UpdateOrder,
                    new
                    {
                        order.Id,
                        order.DateCreate,
                        order.ComplitionDate,
                        order.ManagerId,
                        order.ClientId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteOrder(int id)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();

                return sqlConnect.Execute(
                    StoredProcedures.DeleteOrder,
                    new { id },
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
                        OrderDto tmp = null;

                        foreach (var o in result)
                        {
                            if (o.Id == order.Id)
                            {
                                tmp = o;
                            }
                        }

                        if (tmp is null)
                        {
                            tmp = order;
                            result.Add(tmp);
                        }

                        tmp.Client = client;

                        return order;
                    },
                    new { managerId },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<OrderDto> GetAllOrdersByClientId(int ClientId)
        {
            using (var SqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                var result = new List<OrderDto>();
                SqlConnect.Open();
                SqlConnect.Query<OrderDto, ManagerDto, OrderDto>(
                    StoredProcedures.GetAllOrdersByClientId,
                    (order, manager) =>
                    {
                        OrderDto tmp = null;

                        foreach (var o in result)
                        {
                            if (o.Id == order.Id)
                            {
                                tmp = o;
                            }
                        }

                        if (tmp is null)
                        {
                            tmp = order;
                            result.Add(tmp);
                        }

                        tmp.Manager = manager;

                        return order;
                    },
                    new { ClientId },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<OrderDto> GetAllOrders()
        {
            using (var SqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                var result = new List<OrderDto>();
                SqlConnect.Open();
                SqlConnect.Query<OrderDto, ClientsDto,ManagerDto, OrderDto>(
                    StoredProcedures.GetAllOrders,
                    (order, client,manager) =>
                    {
                        OrderDto tmp = null;

                        foreach (var o in result)
                        {
                            if (o.Id == order.Id)
                            {
                                tmp = o;
                            }
                        }

                        if (tmp is null)
                        {
                            tmp = order;
                            result.Add(tmp);
                        }

                        tmp.Client = client;
                        tmp.Manager = manager;

                        return order;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}