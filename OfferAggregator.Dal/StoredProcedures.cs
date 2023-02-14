using OfferAggregator.Dal.Models;

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

        public const string AddTag = "AddTag";

        public const string AddTagProduct = "AddTagProduct";

        public const string GetAllTags = "GetAllTags";

        public const string GetAllTagsByProductId = "GetAllTagsByProductId";

        public const string UpdateTag = "UpdateTag";

        public const string DeleteTag = "DeleteTag";

        public const string DeleteProductsReviews = "DeleteProductsReviews";

        public const string DeleteStock = "DeleteStock";

        public const string DeleteTagProduct = "DeleteTagProduct";

        public const string AddClient = "AddClient";

        public const string DeleteClient = "DeleteClient";

        public const string UpdateClient = "UpdateClient";

        public const string GetAllClients = "GetAllClients";
                
        public const string GetAllPurchasedProductsByClientId = "GetAllPurchasedProductsByClientId";

        public const string AddProductToOrders = "AddProductToOrders";

        public const string AddClientWishes = "AddClientWishes";

        public const string GetClientWishesByClientId = "GetClientWishesByClientId";

        public const string UpdateClientWishesById = "UpdateClientWishesById";

        public const string DeleteClientWishesById = "DeleteClientWishesById";

        public const string GetAllInfoInOrderById = "GetAllInfoInOrderById";

        public const string UpdateCountInOrdersProducts = "UpdateCountInOrdersProducts";

        public const string AddCommentForClient = "AddCommentForClient";

        public const string UpdateCommentForClient = "UpdateCommentForClient";

        public const string DeleteCommentForClient = "DeleteCommentForClient";

        public const string DeleteProductReviewsByProductId = "DeleteProductReviewByProductId";

        public const string DeleteTagProductByProductId = "DeleteTagProductByProductId";

        public const string GetProductById = "GetProductById";

        public const string AddCommentForOrder = "AddCommentForOrder";

        public const string UpdateCommentForOrder = "UpdateCommentForOrder";

        public const string DeleteCommentForOrder = "DeleteCommentForOrder";

        public const string GetGroupById = "GetGroupById";

        public const string GetFullProductById = "GetFullProductById";

        public const string DeleteCommentForClient = "DeleteCommentForClient";

        public const string GetFullProducts = "GetFullProducts";

        public const string GetManagerByLogin = "GetManagerByLogin";
    }
}
