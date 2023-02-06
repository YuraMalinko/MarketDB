using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsReviewsAndStocksRepository
    {
        public int AddAmountToStocks(StocksDtoWithProductName stock);

        public int AddScoreAndCommentToProductReview(ProductReviewsDto prReview);

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductId(int productId);

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId);

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProducts();

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductsByClientId(int clientId);

        public StocksDtoWithProductName GetAmountByProductId(int id);

        public List<StocksDtoWithProductName> GetAmountsOfAllProducts();

        public bool UpdateAmountOfStocks(int productId, int changeAmount);

        public bool UpdateScoreAndCommentOfProductsReviews(ProductReviewsDto productReviews);
    }
}