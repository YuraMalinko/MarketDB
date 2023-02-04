 CREATE PROCEDURE [dbo].[DeleteProductReviewByProductId]
  @productId int
  AS
  delete ProductsReviews
  Where [ProductId] = @productId