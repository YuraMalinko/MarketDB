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
                return sqlCnctn.Execute(
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
    }
}
