﻿CREATE PROCEDURE GetAllScoresAndCommentsForProductByProductIDAndClientId
@productId int,
@clientId int
AS
SELECT PR.ProductId, P.Name, PR.Score, PR.Comment, PR.ClientId
FROM [dbo].[ProductsReviews] AS PR
LEFT JOIN [dbo].[Products] AS P ON
PR.ProductId=P.Id
WHERE
P.IsDeleted =0 AND
PR.ProductId = @productId AND
PR.ClientId = @clientId