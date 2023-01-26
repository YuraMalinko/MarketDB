CREATE PROCEDURE GetAllCommentsForProducts
AS
SELECT PR.ProductId, P.Name, PR.Comment, PR.ClientId
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
