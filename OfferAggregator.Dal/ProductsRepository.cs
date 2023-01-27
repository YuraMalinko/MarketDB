using OfferAggregator.Dal.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OfferAggregator.Dal
{
    public class ProductsRepository
    {
        public int AddProduct(string name)
        {
            using (var sqlCnctn = new SqlConnection(Options.))
        }
    }
}
