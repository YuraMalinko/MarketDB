CREATE PROCEDURE GetScoresAndCommentsForAllProductsByClientId
@clientId int
AS
SELECT PR.ClientId, PR.ProductId, P.Name, PR.Score, PR.Comment
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
WHERE
PR.ClientId = @clientId