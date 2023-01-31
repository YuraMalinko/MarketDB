﻿CREATE PROCEDURE GetAllScoresAndCommentsForProductByProductId
@productId int
AS
SELECT PR.ProductId, P.Name, PR.Score, PR.Comment, PR.ClientId
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
WHERE
P.IsDeleted = 0 AND
PR.ProductId = @productId