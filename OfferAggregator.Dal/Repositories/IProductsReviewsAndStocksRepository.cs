using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsReviewsAndStocksRepository
    {
        int AddAmountToStocks(StocksDtoWithProductName stock);
        int AddScoreAndCommentToProductReview(ProductReviewsDto prReview);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductId(int productId);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId);
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProducts();
        List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductsByClientId(int clientId);
        StocksDtoWithProductName GetAmountByProductId(int id);
        List<StocksDtoWithProductName> GetAmountsOfAllProducts();
        bool UpdateAmountOfStocks(int productId, int changeAmount);
        bool UpdateScoreAndCommentOfProductsReviews(ProductReviewsDto productReviews);
    }
}