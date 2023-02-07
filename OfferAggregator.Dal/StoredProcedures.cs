namespace OfferAggregator.Dal
{
    public class StoredProcedures
    {
        public const string AddProduct = "AddProduct";

        public const string GetAllProducts = "GetAllProducts";

        public const string GetAllProductsByGroupId = "GetAllProductsByGroupId";

        public const string UpdateProduct = "UpdateProduct";

        public const string DeleteProduct = "DeleteProduct";

        public const string AddAmountToStocks = "AddAmountToStocks";

        public const string AddScoreAndCommentToProductReview = "AddScoreAndCommentToProductReview";

        public const string GetAllScoresAndCommentsForProducts = "GetAllScoresAndCommentsForProducts";

        public const string GetAmountByProductId = "GetAmountByProductId";

        public const string GetAmountsOfAllProducts = "GetAmountsOfAllProducts";

        public const string GetAllScoresAndCommentsForProductsByClientId = "GetAllScoresAndCommentsForProductsByClientId";

        public const string GetAllScoresAndCommentsForProductByProductId = "GetAllScoresAndCommentsForProductByProductId";

        public const string GetAllScoresAndCommentsForProductByProductIDAndClientId = "GetAllScoresAndCommentsForProductByProductIDAndClientId";

        public const string UpdateAmountOfStocks = "UpdateAmountOfStocks";

        public const string UpdateScoreAndCommentOfProductsReviews = "UpdateScoreAndCommentOfProductsReviews";
        public const string GetAllManagers = "GetAllManagers";

        public const string AddManager = "AddManager";

        public const string GetSingleManager = "GetSingleManager";

        public const string DeleteManager = "DeleteManager";

        public const string UpdateManager = "UpdateManager";

        public const string AddOrder = "AddOrder";

        public const string DeleteOrder = "DeleteOrder";

        public const string UpdateOrder = "UpdateOrder";

        public const string GetAllOrdersByIdManager = "GetAllOrdersByIdManager";

        public const string GetAllOrdersByClientId = "GetAllOrdersByClientId";

        public const string GetAllOrders = "GetAllOrders";

        public const string DeleteProductReviewByProductId = "DeleteProductReviewByProductId";

        public const string DeleteTagProductByProductId = "DeleteTagProductByProductId";


        public const string GetProductById = "GetProductById";

    }
}
