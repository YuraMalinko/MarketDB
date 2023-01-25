CREATE PROCEDURE GetAmountByProductId
@productId int
AS
SELECT S.[ProductId], S.[Amount]
FROM [dbo].[Stocks] as S
LEFT JOIN [dbo].[Products] as P ON
P.Id = S.ProductId
WHERE
S.[ProductId]=@productId AND
P.[IsDeleted] = 0