CREATE PROCEDURE UpdateScoreAndCommentOfProductsReviews
@productId int,
@clientId int,
@score int,
@comment nvarchar(1000)
AS
UPDATE [dbo].[ProductsReviews]
SET 
[Comment]=@comment,
[Score] = @score
WHERE
[ProductId] = @productId AND
[ClientId] = @clientId