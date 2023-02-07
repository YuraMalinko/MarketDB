using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsReviewsAndStocksRepository
    {
        bool AddAmountToStocks(StocksDtoWithProductName stock);
        int AddScoreAndCommentToProductReview(ProductReviewsDto prReview);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductId(int productId);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProducts();
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductsByClientId(int clientId);
        StocksDtoWithProductName GetAmountByProductId(int productId);
        List<StocksDtoWithProductName> GetAmountsOfAllProducts();
        bool UpdateAmountOfStocks(StocksDtoWithProductName stock);
        bool UpdateScoreAndCommentOfProductsReviews(ProductReviewsDto productReviews);
        bool DeleteProductReviewByProductId(int productId);
    }
}