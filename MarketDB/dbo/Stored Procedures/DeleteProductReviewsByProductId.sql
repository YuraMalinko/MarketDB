 CREATE PROCEDURE [dbo].[DeleteProductReviewsByProductId]
  @productId int
  AS
  delete ProductsReviews
  Where [ProductId] = @productId