CREATE PROCEDURE GetAllScoresAndCommentsForProductByProductIDAndClientId
@productId int,
@clientId int
AS
SELECT P.Id AS ProductId, P.Name, PR.Score, PR.Comment, PR.ClientId
FROM [dbo].[Products] AS P
LEFT JOIN [dbo].[ProductsReviews] AS PR ON
PR.ProductId=P.Id AND PR.ClientId = @clientId
WHERE
P.IsDeleted =0 AND
P.Id = @productId 