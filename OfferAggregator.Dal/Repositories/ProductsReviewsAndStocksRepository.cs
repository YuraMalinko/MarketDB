using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class ProductsReviewsAndStocksRepository : IProductsReviewsAndStocksRepository
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
                    prReview,
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
                            crnt.ProductReviews = new List<ProductReviewsDto>();
                        }

                        crnt.ProductReviews.Add(prReview);

                        return prScoreAndComment;
                    },
                    splitOn: "Score",
                    commandType: CommandType.StoredProcedure
                    ).ToList();

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

        public List<StocksDtoWithProductName> GetAmountsOfAllProducts()
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();

                return sqlCnctn.Query<StocksDtoWithProductName>(
                    StoredProcedures.GetAmountsOfAllProducts,
                    commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductsByClientId(int clientId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ProductWithScoresAndCommentsDto> result = new List<ProductWithScoresAndCommentsDto>();
                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProductsByClientId,
                    (scoresAndComments, reviews) =>
                    {
                        reviews.ProductId = scoresAndComments.ProductId;
                        ProductWithScoresAndCommentsDto crnt = null;

                        foreach (var product in result)
                        {
                            if (product.ProductId == scoresAndComments.ProductId)
                            {
                                crnt = product;
                            }
                        }

                        if (crnt is null)
                        {
                            crnt = scoresAndComments;
                            result.Add(crnt);
                            crnt.ProductReviews = new List<ProductReviewsDto>();
                        }

                        crnt.ProductReviews.Add(reviews);

                        return scoresAndComments;
                    },
                    new { clientId },
                    splitOn: "Score",
                    commandType: CommandType.StoredProcedure
                    ).ToList();

                return result;
            }
        }

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ProductWithScoresAndCommentsDto> result = new List<ProductWithScoresAndCommentsDto>();
                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProductByProductId,
                    (scoresAndComments, reviews) =>
                    {
                        reviews.ProductId = scoresAndComments.ProductId;
                        ProductWithScoresAndCommentsDto crnt = null;

                        foreach (var product in result)
                        {
                            if (product.ProductId == scoresAndComments.ProductId)
                            {
                                crnt = product;
                            }
                        }

                        if (crnt is null)
                        {
                            crnt = scoresAndComments;
                            result.Add(crnt);
                            crnt.ProductReviews = new List<ProductReviewsDto>();
                        }

                        crnt.ProductReviews.Add(reviews);

                        return scoresAndComments;
                    },
                    new { productId },
                    splitOn: "Score",
                    commandType: CommandType.StoredProcedure
                    ).ToList();

                return result;
            }
        }

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                List<ProductWithScoresAndCommentsDto> result = new List<ProductWithScoresAndCommentsDto>();
                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProductByProductIDAndClientId,
                    (scoresAndComments, reviews) =>
                    {
                        reviews.ProductId = scoresAndComments.ProductId;
                        ProductWithScoresAndCommentsDto crnt = null;

                        foreach (var product in result)
                        {
                            if (product.ProductId == scoresAndComments.ProductId)
                            {
                                crnt = product;
                            }
                        }

                        if (crnt is null)
                        {
                            crnt = scoresAndComments;
                            result.Add(crnt);
                            crnt.ProductReviews = new List<ProductReviewsDto>();
                        }

                        crnt.ProductReviews.Add(reviews);

                        return scoresAndComments;
                    },
                    new { clientId, productId },
                    splitOn: "Score",
                    commandType: CommandType.StoredProcedure
                    ).ToList();

                return result;
            }
        }

        public bool UpdateAmountOfStocks(int productId, int changeAmount)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                     StoredProcedures.UpdateAmountOfStocks,
                     new { productId, changeAmount },
                     commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool UpdateScoreAndCommentOfProductsReviews(ProductReviewsDto productReviews)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateScoreAndCommentOfProductsReviews,
                    new { productReviews.ProductId, productReviews.ClientId, productReviews.Score, productReviews.Comment },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}