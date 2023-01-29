using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using OfferAggregator.Dal.Options;
using System.Data;

namespace OfferAggregator.Dal
{
    public class ManagerRepository
    {
        public List<ManagerDto> GetAllManagers()
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.Query<ManagerDto>(
                    StoredProcedures.GetAllManagers,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ManagerDto GetSingleManager(string login, string password)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.QuerySingle<ManagerDto>(
                    StoredProcedures.GetSingleManager,
                    new { login, password },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int AddManager(ManagerDto manager)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.AddManager,
                    new { manager.Login, manager.Password },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int AddManagerDifferently(string login, string password)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.AddManager,
                    new { login, password },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int UpdateManager(ManagerDto manager)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.UpdateManager,
                    new { manager.Id, manager.Login, manager.Password },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteManager(int id)
        {
            using (var sqlConnect = new SqlConnection(ConnectOptions.ConnectString))
            {
                sqlConnect.Open();
                return sqlConnect.Execute(
                    StoredProcedures.DeleteManager,
                    new { id },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}