using OfferAggregator.Dal.Models;

namespace OfferAggregator.Dal.Repositories
{
    public interface IProductsReviewsAndStocksRepository
    {
        public bool AddAmountToStocks(StocksDtoWithProductName stock);

        public bool AddScoreOrCommentToProductReview(ProductReviewsDto prReview);

        public ProductWithScoresAndCommentsDto GetAllScoresAndCommentsForProductByProductId(int productId);

        public ProductWithScoresAndCommentsDto GetAllScoresAndCommentsForProductByProductIDAndClientId(int productId, int clientId);

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProducts();

        public List<ProductWithScoresAndCommentsDto> GetAllScoresAndCommentsForProductsByClientId(int clientId);

        public StocksDtoWithProductName GetAmountByProductId(int productId);

        public List<StocksDtoWithProductName> GetAmountsOfAllProducts();

        public bool UpdateAmountOfStocks(StocksDtoWithProductName stockProduct);

        public bool UpdateScoreAndCommentOfProductsReviews(ProductReviewsDto productReviews);

        public bool DeleteProductReviewsByProductId(int productId);
    }
}