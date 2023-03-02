CREATE PROCEDURE [dbo].[UpdateScore]
@productId int,
@clientId int,
@score int
AS
UPDATE [dbo].[ProductsReviews]
SET 
[Score] = @score
WHERE
[ProductId] = @productId AND
[ClientId] = @clientId