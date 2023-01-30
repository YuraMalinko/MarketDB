using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfferAggregator.Dal
{
    public class StoredProcedures
    {
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
    }
}
