using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        public bool DeleteTagProductByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteTagProductByProductId,
                    new { productId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
