using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class TagsRepository
    {
        public int AddTag(string name)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.QuerySingle<int>(
                    StoredProcedures.AddTag,
                    new { name},
                    commandType:CommandType.StoredProcedure);
            }
        }
    }
}
