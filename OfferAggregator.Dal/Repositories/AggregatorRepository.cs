using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class AggregatorRepository : IAggregatorRepository
    {
        public List<ComboTagGroupDto> GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(int clientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                List<ComboTagGroupDto> result = new List<ComboTagGroupDto>();
                sqlConnection.Open();
                sqlConnection.Query<ComboTagGroupDto>(
                    StoredProcedures.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId,
                    new { clientId },
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<ComboTagGroupDto> GetComboTagGroupOfLikeOrDislikeByClientId(int clientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                List<ComboTagGroupDto> result = new List<ComboTagGroupDto>();
                sqlConnection.Open();
                result = sqlConnection.Query<ComboTagGroupDto>(
                    StoredProcedures.GetComboTagGroupOfLikeOrDislikeByClientId,
                    new { clientId },
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

        public List<ComboTagGroupDto> GetGroupTagCountProductsCountOrdersByClientId(int clientId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ComboTagGroupDto> result = new List<ComboTagGroupDto>();
                sqlCnctn.Open();
                result = sqlCnctn.Query<ComboTagGroupDto>(
                    StoredProcedures.GetGroupTagCountProductsCountOrdersByClientId,
                    new { clientId },
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }
    }
}