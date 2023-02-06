CREATE PROCEDURE [dbo].[DeleteProductsReviews]
  @clientId int,
  @productId int
  AS
  DELETE ProductsReviews
  WHERE ClientId = @clientId AND
  ProductId = @productId
