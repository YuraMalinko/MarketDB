using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal
{
    public class ProductsRepository
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

        public int UpdateProduct(ProductsDto product)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Execute(
                    StoredProcedures.UpdateProductsName,
                    new { product.Id, product.Name, product.GroupId },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public int DeleteProduct(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Execute(
                    StoredProcedures.DeleteProduct,
                    new { id},
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
