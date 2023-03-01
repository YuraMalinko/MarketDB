using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class TagsRepository : ITagsRepository
    {
        public int AddTag(TagDto tag)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.QuerySingle<int>(
                    StoredProcedures.AddTag,
                    new { tag.Name },
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
                    new { productId },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public bool UpdateTag(TagDto tag)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateTag,
                    tag,
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteTag(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteTag,
                    new { id },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteTagProduct(TagProductDto tagProduct)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            { 
            sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteTagProduct,
                    tagProduct,
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
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

        public bool DeleteTagByProductIdAndTagId(int productId, int tagId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteTagByProductIdAndTagId,
                    new { productId, tagId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public TagDto GetTagById(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<TagDto>(
                    StoredProcedures.GetTagById,
                    new { id},
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}