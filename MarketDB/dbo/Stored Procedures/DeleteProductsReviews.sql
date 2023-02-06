CREATE PROCEDURE [dbo].[DeleteProductsReviews]
  @clientId int,
  @productId int
  AS
  delete ProductsReviews
  Where ClientId = @clientId AND
  ProductId = @productId
