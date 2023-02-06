using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class ClientsWishesRepository
    {
        public bool AddClientWishes(ClientWishesDto clientWishes)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.AddClientWishes,
                    clientWishes,
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
