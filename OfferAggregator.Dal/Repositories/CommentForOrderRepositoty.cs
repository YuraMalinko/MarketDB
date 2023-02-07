using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class CommentForOrderRepositoty: ICommentForOrderRepository
    {
        public int AddCommentOrder(CommenForOrderDto comment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.QuerySingle<int>(
                    StoredProcedures.AddCommentForOrder,
                    new
                    { 
                        comment.Text, 
                        comment.OrderId 
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateCommentOrder(CommenForOrderDto comment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.UpdateCommentForOrder,
                    new
                    {
                        comment.Id,
                        comment.Text,
                        comment.OrderId,
                    },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public bool DeleteCommentOrder(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.DeleteCommentForOrder,
                    new 
                    { 
                        id 
                    },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
