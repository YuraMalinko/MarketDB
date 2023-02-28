using Dapper;
using Microsoft.Data.SqlClient;
using OfferAggregator.Dal.Models;
using System.Data;

namespace OfferAggregator.Dal.Repositories
{
    public class ProductsReviewsAndStocksRepository : IProductsReviewsAndStocksRepository
    {
        public bool AddAmountToStocks(StocksDtoWithProductName stock)
        {
            using (var sqlCnct = new SqlConnection(Options.ConnectionString))
            {
                sqlCnct.Open();

                int result = sqlCnct.Execute(
                     StoredProcedures.AddAmountToStocks,
                     new { stock.Amount, stock.ProductId },
                                     commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool AddScoreOrCommentToProductReview(ProductReviewsDto prReview)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();

                int result = sqlCnctn.Execute(
                    StoredProcedures.AddScoreAndCommentToProductReview,
                    new { prReview.ProductId, prReview .ClientId, prReview.Score, prReview.Comment },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
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

        public StocksDtoWithProductName GetAmountByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();

                return sqlCnctn.Query<StocksDtoWithProductName>(StoredProcedures.GetAmountByProductId,
                    new { productId },
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

        public ProductWithScoresAndCommentsDto GetAllScoresAndCommentsForProductByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                ProductWithScoresAndCommentsDto result = null;
                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProductByProductId,
                    (scoresAndComments, reviews) =>
                    {
                        if (result == null)
                        {
                            result = scoresAndComments;
                            result.ProductReviews = new List<ProductReviewsDto>();
                        }

                        if (reviews != null)
                        {
                            result.ProductReviews.Add(reviews);
                            reviews.ProductId = scoresAndComments.ProductId;
                        }

                        return scoresAndComments;
                    },
                    new { productId },
                    splitOn: "ClientId",
                    commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public ProductWithScoresAndCommentsDto GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                ProductWithScoresAndCommentsDto result = null;
                sqlCnctn.Open();
                sqlCnctn.Query<ProductWithScoresAndCommentsDto, ProductReviewsDto, ProductWithScoresAndCommentsDto>(
                    StoredProcedures.GetAllScoresAndCommentsForProductByProductIDAndClientId,
                    (scoresAndComments, reviews) =>
                    {
                        if (result == null)
                        {
                            result = scoresAndComments;
                            result.ProductReviews = new List<ProductReviewsDto>();
                        }

                        if (reviews != null)
                        {
                            result.ProductReviews.Add(reviews);
                            reviews.ProductId = result.ProductId;
                        }                                              

                        return scoresAndComments;
                    },
                    new { clientId, productId },
                    splitOn: "ClientId",
                    commandType: CommandType.StoredProcedure
                    );

                return result;
            }
        }

        public bool UpdateAmountOfStocks(StocksDtoWithProductName stockProduct)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                     StoredProcedures.UpdateAmountOfStocks,
                     new { stockProduct.ProductId, stockProduct.Amount },
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

        public bool DeleteProductsReviews(ProductReviewsDto productReview)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteProductsReviews,
                    new { productReview.ProductId, productReview.ClientId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteStock(StocksDtoWithProductName stock)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteStock,
                    new { stock.Amount, stock.ProductId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool DeleteProductReviewsByProductId(int productId)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.DeleteProductReviewsByProductId,
                    new { productId },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool AddScoreToProductReview(ProductReviewsDto prReview)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();

                int result = sqlCnctn.Execute(
                    StoredProcedures.AddScore,
                    new { prReview.ProductId, prReview.ClientId, prReview.Score },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool AddCommentToProductReview(ProductReviewsDto prReview)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();

                int result = sqlCnctn.Execute(
                    StoredProcedures.AddComment,
                    new { prReview.ProductId, prReview.ClientId, prReview.Comment },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool UpdateScoreOfProductReview(ProductReviewsDto productReviews)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateScore,
                    new { productReviews.ProductId, productReviews.ClientId, productReviews.Score },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }

        public bool UpdateCommentOfProductReview(ProductReviewsDto productReviews)
        {
            using (var sqlCnctn = new SqlConnection(Options.ConnectionString))
            {
                sqlCnctn.Open();
                int result = sqlCnctn.Execute(
                    StoredProcedures.UpdateComment,
                    new { productReviews.ProductId, productReviews.ClientId, productReviews.Comment },
                    commandType: CommandType.StoredProcedure);

                return result > 0;
            }
        }
    }
}