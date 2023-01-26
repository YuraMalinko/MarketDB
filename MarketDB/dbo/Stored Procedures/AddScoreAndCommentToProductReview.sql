CREATE PROCEDURE AddScoreAndCommentToProductReview
@productId int,
@clientId int,
@score int,
@comment nvarchar(1000)
AS
INSERT INTO [dbo].[ProductsReviews] ([Score],[Comment],[ClientId],[ProductId])
VALUES (@score, @comment, @clientId, @productId)