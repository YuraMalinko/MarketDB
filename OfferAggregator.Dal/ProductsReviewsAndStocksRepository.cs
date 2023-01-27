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

        public int AddScoreAndCommentToProductReview(ProductReviewsDto prReview)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            { 
            sqlCnctn.Open();
                return sqlCnctn.Execute(
                    StoredProcedures.AddScoreAndCommentToProductReview,
                    new { prReview.ProductId, prReview.ClientId, prReview.Score, prReview.Comment},
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
