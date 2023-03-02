using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class AggregatorRepository:IAggregatorRepository
    {
        public List<ComboTagGroupDto> GetAvgScoreGroupeAndTagOnProductsReviewsByClientId(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                List<ComboTagGroupDto> result = new List<ComboTagGroupDto>();
                sqlConnection.Open();
                sqlConnection.Query<ComboTagGroupDto, GroupDto, TagDto, ComboTagGroupDto>(
                    StoredProcedures.GetAvgScoreGroupeAndTagOnProductsReviewsByClientId,
                    (combo, group, tag) =>
                    {
                        ComboTagGroupDto tmp = null;

                        if (result.Exists(c => c.Equals(combo)))
                        {
                            tmp = result.Find(c => c.Equals(combo));
                        }
                        else
                        {
                            tmp = combo;
                            result.Add(tmp);
                        }

                        tmp.Group = group;

                        if (tag != null)
                        {
                            tmp.Tag = tag;
                        }

                        return combo;
                    },
                    new {id},
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure).ToList();

                return result;
            }
        }

    }
}
