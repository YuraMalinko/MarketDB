CREATE PROCEDURE UpdateScoreAndCommentOfProductsReviews
@productId int,
@clientId int,
@changeScore int,
@changeComment nvarchar(1000)
AS
UPDATE [dbo].[ProductsReviews]
SET [Comment]=@changeComment,
[Score] = @changeScore
WHERE
[ProductId] = @productId AND [ClientId] = @clientId