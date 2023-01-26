CREATE PROCEDURE UpdateScoreOfProductsReviews
@productId int,
@clientId int,
@changeScore int
AS
UPDATE [dbo].[ProductsReviews]
SET [Score]=@changeScore
WHERE
[ProductId] = @productId AND [ClientId] = @clientId