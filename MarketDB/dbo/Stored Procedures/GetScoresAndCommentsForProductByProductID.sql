﻿CREATE PROCEDURE GetScoresAndCommentsForProductByProductID
@productId int
AS
SELECT PR.ProductId, P.Name, PR.Score, PR.Comment, PR.ClientId
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
WHERE
PR.ProductId = @productId