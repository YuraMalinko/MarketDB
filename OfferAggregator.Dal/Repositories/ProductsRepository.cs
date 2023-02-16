using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public int AddProduct(ProductsDto product)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.QuerySingle<int>(
                    StoredProcedures.AddProduct,
                    new { product.Name, product.GroupId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductsDto> GetAllProducts()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<ProductsDto>(
                    StoredProcedures.GetAllProducts,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ProductsDto> GetAllProductsByGroupId(int groupId)
        {
            using (var sqlCncth = new SqlConnection(Options.ConnectionString))
            {
                sqlCncth.Open();
                return sqlCncth.Query<ProductsDto>(
                    StoredProcedures.GetAllProductsByGroupId,
                    new { groupId },
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public ProductsDto GetProductById(int id)
        {
            using (var sqlCncth = new SqlConnection(Options.ConnectionString))
            {
                sqlCncth.Open();
                return sqlCncth.Query<ProductsDto>(
                    StoredProcedures.GetProductById,
                    new { id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public bool UpdateProduct(ProductsDto product)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                     StoredProcedures.UpdateProduct,
                     new { product.Id, product.Name, product.GroupId },
                     commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteProduct(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteProduct,
                    new { id },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public FullProductDto GetFullProductById(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                FullProductDto result = null;
                sqlCnctn.Query<FullProductDto, TagDto, FullProductDto>(
                    StoredProcedures.GetFullProductById,
                    (fullProduct, tag) =>
                    {
                        if (result is null)
                        {
                            result = fullProduct;
                            result.Tags = new List<TagDto>();
                        }
                        if (tag != null)
                        {
                            result.Tags.Add(tag);
                        }

                        return fullProduct;
                    },
                    new { id },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public List<FullProductDto> GetFullProducts()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                List<FullProductDto> fullProducts = new List<FullProductDto>();
                FullProductDto result = null;
                sqlCnctn.Query<FullProductDto, TagDto, FullProductDto>(
                    StoredProcedures.GetFullProducts,
                    (fullProductDto, tagDto) =>
                    {
                        if (result is null)
                        {
                            result = fullProductDto;
                            result.Tags = new List<TagDto>();
                            fullProducts.Add(result);
                        }

                        if (result.Id != fullProductDto.Id)
                        {
                            result = fullProductDto;
                            result.Tags = new List<TagDto>();
                            fullProducts.Add(result);
                        }
                        if (tagDto != null)
                        {
                            result.Tags.Add(tagDto);
                        }

                        return fullProductDto;
                    },
                    splitOn: "Id",
                    commandType: CommandType.StoredProcedure);

                return fullProducts;
            }
        }

        public List<ProductsStatisticDto> GetProductsStatistic()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<ProductsStatisticDto>(
                    StoredProcedures.GetProductsStatistic,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }
}
