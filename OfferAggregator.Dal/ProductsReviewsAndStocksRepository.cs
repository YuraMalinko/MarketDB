using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal
{
    public class ProductsReviewsAndStocksRepository
    {
        public int AddAmountToStocks(StocksDto stock)
        {
            using (var sqlCnct = new SqlConnection(Options.ConnectionString))
            { 
            sqlCnct.Open();
                return sqlCnct.Execute(
                    StoredProcedures.AddAmountToStocks,
                    new { stock.Amount, stock.ProductId },
                                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
