CREATE PROCEDURE [dbo].[UpdateComment]
@productId int,
@clientId int,
@comment nvarchar(1000)
AS
UPDATE [dbo].[ProductsReviews]
SET 
[Comment] = @comment
WHERE
[ProductId] = @productId AND
[ClientId] = @clientId