using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class CommentForClientRepository : ICommentForClientRepository
    {
        public int AddComment(CommentForClientDto comment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.QuerySingle<int>(
                    StoredProcedures.AddCommentForClient,
                    new
                    { comment.Text, comment.ClientId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool UpdateComment(CommentForClientDto comment)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.UpdateCommentForClient,
                    new
                    {
                        comment.Id,
                        comment.Text,
                        comment.ClientId,
                    },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

        public bool DeleteComment(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Options.ConnectionString))
            {
                sqlConnection.Open();

                return sqlConnection.Execute(
                    StoredProcedures.DeleteCommentForClient,
                    new { id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
