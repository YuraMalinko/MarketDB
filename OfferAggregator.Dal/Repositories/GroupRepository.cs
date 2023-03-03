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

        public List<GroupDto> GetAllGroups()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<GroupDto>(
                    StoredProcedures.GetAllGroups,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public int AddGroup(string name)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.QuerySingle<int>(
                    StoredProcedures.AddGroup,
                    new { name},
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateGroup(GroupDto group)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateGroup,
                    new { group.Id, group.Name},
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteGroup(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteGroup,
                    new { id },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public List<ProductsDto> GetAllProductsByGroupIdWitchExist(int groupId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<ProductsDto>(
                    StoredProcedures.GetAllProductsByGroupIdWitchExist,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
