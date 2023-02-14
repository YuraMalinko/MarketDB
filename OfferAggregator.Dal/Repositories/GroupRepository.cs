using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public GroupDto GetGroupById(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<GroupDto>(
                    StoredProcedures.GetGroupById,
                    new { id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
