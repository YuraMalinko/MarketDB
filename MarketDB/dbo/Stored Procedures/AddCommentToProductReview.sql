CREATE PROCEDURE AddCommentToProductReview
@productId int,
@clientId int,
@comment nvarchar(1000)
AS
INSERT INTO [dbo].[ProductsReviews] ([Comment],[ClientId],[ProductId])
VALUES (@comment, @clientId, @productId)