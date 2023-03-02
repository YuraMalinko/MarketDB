CREATE PROCEDURE [dbo].[AddScore]
@productId int,
@clientId int,
@score int
AS
INSERT INTO [dbo].[ProductsReviews] ([Score],[ClientId],[ProductId])
VALUES (@score, @clientId, @productId)
