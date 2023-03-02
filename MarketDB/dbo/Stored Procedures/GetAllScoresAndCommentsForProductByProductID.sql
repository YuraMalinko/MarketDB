CREATE PROCEDURE GetAllScoresAndCommentsForProductByProductId
@productId int
AS
SELECT P.Id AS ProductId, P.Name, C.Id AS ClientId, C.Name, PR.Score, PR.Comment 
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Clients] AS C ON
PR.ClientId = C.Id
RIGHT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id AND C.[IsDeleted] =0
WHERE
P.IsDeleted = 0 AND
P.Id = @productId