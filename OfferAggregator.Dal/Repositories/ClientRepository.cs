using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;


namespace OfferAggregator.Dal.Repositories
{
    public class ClientRepository : IClientRepository
    {
        public int AddClient(ClientsDto client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.QuerySingle<int>(
                    StoredProcedures.AddClient,
                    new
                    { client.Name, client.PhoneNumber },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateClient(ClientsDto client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.UpdateClient,
                    new
                    {
                        client.Id,
                        client.Name,
                        client.PhoneNumber,
                    },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public bool DeleteClient(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.DeleteClient,
                    new { id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public List<ClientsDto> GetAllClients()
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                List<ClientsDto> result = new List<ClientsDto>();
                sqlConnection.Open();
                sqlConnection.Query<ClientsDto, CommentForClientDto, ClientsDto>(
                    StoredProcedures.GetAllClients,
                    (client, comment) =>
                    {
                        ClientsDto tmp = null;

                        if (result.Exists(c => c.Id == client.Id))
                        {
                            tmp = result.Find(c => c.Id == client.Id);
                        }
                        else
                        {
                            tmp = client;
                            result.Add(tmp);
                        }

                        if (tmp.CommentsForClient is null)
                        {
                            tmp.CommentsForClient = new List<CommentForClientDto>();
                        }

                        if (comment is not null)
                        {
                            tmp.CommentsForClient.Add(comment);
                        }

                        return client;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<PurchasedProductDto> GetAllPurchasedProductsByClientId(int id)
        {
            var result = new List<PurchasedProductDto>();

            using (var sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();
                sqlConnection.Query<PurchasedProductDto, GroupDto, TagDto, PurchasedProductDto>(
                    StoredProcedures.GetAllPurchasedProductsByClientId,
                    (product, group, tag) =>
                    {
                        PurchasedProductDto tmp = null;

                        if (result.Exists(p => p.Id == product.Id))
                        {
                            tmp = result.Find(p => p.Id == product.Id);
                        }
                        else
                        {
                            tmp = product;
                            result.Add(tmp);
                        }

                        tmp.Group = group;

                        if (tmp.Tags is null)
                        {
                            tmp.Tags = new List<TagDto>();
                        }

                        if (tag is not null)
                        {
                            tmp.Tags.Add(tag);
                        }

                        return product;
                    },
                    new { id },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList(); ;

                return result;
            }
        }

        public ClientsDto GetClientById(int id)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();
                return sqlConnect.Query<ClientsDto>(
                   StoredProcedures.GetClientById,
                   new { id },
                   commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

        }

        public List<ClientsDto> GetClientsByName(string name)
        {
            using (var sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();
                return sqlConnection.Query<ClientsDto>(
                    StoredProcedures.GetClientsByName,
                    new { name },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ClientsDto GetClientByPhoneNumber(string phoneNumber)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();

                return sqlConnect.Query<ClientsDto>(
                    StoredProcedures.GetClientByPhoneNumber,
                    new { phoneNumber },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public ClientsProductDto GetClientsWhoOrderedProductByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ClientsDto> clientsList = new List<ClientsDto>();
                ClientsProductDto result = null;
                sqlCnctn.Open();
                sqlCnctn.Query< ClientsDto, ClientsProductDto, ClientsProductDto >(
                    StoredProcedures.GetClientsWhoOrderedProductByProductId,
                    (client, clientsProduct ) =>
                    {
                        if (result is null)
                        {
                            result = clientsProduct;
                            result.Clients= clientsList;
                        }
                        clientsList.Add(client);

                        return clientsProduct;
                    },
                    new { productId},
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
