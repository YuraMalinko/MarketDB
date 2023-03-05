CREATE PROCEDURE GetAllScoresAndCommentsForProductsByClientId
@clientId int
AS
SELECT P.Name, PR.ProductId,PR.Score,PR.Comment,PR.ClientId
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
WHERE
P.IsDeleted = 0 AND
PR.ClientId = @clientId