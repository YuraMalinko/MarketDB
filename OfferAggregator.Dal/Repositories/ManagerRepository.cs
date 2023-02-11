using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;
using System.Linq;

namespace OfferAggregator.Dal.Repositories
{
    public class ManagerRepository : IManagerRepository
    {
        public List<ManagerDto> GetAllManagers()
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();

                return sqlConnect.Query<ManagerDto>(
                    StoredProcedures.GetAllManagers,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ManagerDto GetSingleManager(ManagerDto manager)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();

                return sqlConnect.Query<ManagerDto>(
                    StoredProcedures.GetSingleManager,
                    new { manager.Login, manager.Password },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public int AddManager(ManagerDto manager)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();

                return sqlConnect.QuerySingle<int>(
                    StoredProcedures.AddManager,
                    new { manager.Login, manager.Password },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateManager(ManagerDto manager)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.UpdateManager,
                    new { manager.Id, manager.Login, manager.Password },
                    commandType: CommandType.StoredProcedure)>0;
            }
        }

        public bool DeleteManager(int id)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.DeleteManager,
                    new { id },
                    commandType: CommandType.StoredProcedure)>0;
            }
        }

        public ManagerDto GetManagerByLogin(string login)
        {
            using (var sqlConnect = new SqlConnection(Options.ConnectionString))
            {
                sqlConnect.Open();
                return sqlConnect.Query<ManagerDto>(
                    StoredProcedures.GetManagerByLogin,
                    new { login },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}