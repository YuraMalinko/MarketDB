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
                    new { name },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public bool AddTagProduct(TagProductDto tagProduct)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.AddTagProduct,
                    new { tagProduct.TagId, tagProduct.ProductId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public List<TagDto> GetAllTags()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<TagDto>(
                    StoredProcedures.GetAllTags,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<TagDto> GetAllTagsByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<TagDto>(
                    StoredProcedures.GetAllTagsByProductId,
                    new { productId},
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public bool UpdateTagName(TagDto tag)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateTagName,
                    tag,
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}
