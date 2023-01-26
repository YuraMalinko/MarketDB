CREATE PROCEDURE UpdateCommentOfProductsReviews
@productId int,
@clientId int,
@changeComment nvarchar(1000)
AS
UPDATE [dbo].[ProductsReviews]
SET [Comment]=@changeComment
WHERE
[ProductId] = @productId AND [ClientId] = @clientId