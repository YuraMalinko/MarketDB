using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class ClientsWishesRepository : IClientsWishesRepository
    {
        public int AddClientWishes(ClientWishesDto clientWishes)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<int>(
                    StoredProcedures.AddClientWishes,
                    clientWishes,
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public List<ClientWishesDto> GetClientWishesByClientId(ClientWishesDto clientWishes)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<ClientWishesDto>(
                    StoredProcedures.GetClientWishesByClientId,
                    new { clientWishes.ClientId },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public bool UpdateClientWishesById(ClientWishesDto clientWishes)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateClientWishesById,
                    new { clientWishes.Id, clientWishes.GroupId, clientWishes.TagId, clientWishes.IsLiked },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteClientWishesById(ClientWishesDto clientWishes)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteClientWishesById,
                    new { clientWishes.Id},
                    commandType: CommandType.StoredProcedure
                    );

                return result > 0;
            }
        }
    }
}
