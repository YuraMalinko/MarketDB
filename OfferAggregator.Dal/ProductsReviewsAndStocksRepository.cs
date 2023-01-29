using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal
{
    public class ProductsReviewsAndStocksRepository
    {
        public int AddAmountToStocks(StocksDtoWithProductName stock)
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
                    new { prReview.ProductId, prReview.ClientId, prReview.Score, prReview.Comment },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProducts()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ProductWithScoresAndCommentsDto> result = new List<ProductWithScoresAndCommentsDto>();

                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProducts,
                    (prScoreAndComment, prReview) =>
                    {
                        prReview.ProductId = prScoreAndComment.ProductId;
                        ProductWithScoresAndCommentsDto crnt = null;
                        foreach (var p in result)
                        {
                            if (p.ProductId == prScoreAndComment.ProductId)
                            {
                                crnt = p;
                            }
                        }
                        if (crnt is null)
                        {
                            crnt = prScoreAndComment;
                            result.Add(crnt);
                        }
                        if (crnt.ProductReviews is null)
                        {
                            crnt.ProductReviews = new List<ProductReviewsDto>();
                        }
                        crnt.ProductReviews.Add(prReview);


                        return prScoreAndComment;
                    },
                    splitOn: "Score",
                    commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public StocksDtoWithProductName GetAmountByProductId(int id)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                return sqlCnctn.Query<StocksDtoWithProductName>(StoredProcedures.GetAmountByProductId,
                    new { id },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }
    }
}
