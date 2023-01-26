CREATE PROCEDURE GetAmountsOfAllProducts
AS
SELECT S.[ProductId], S.[Amount]
FROM [dbo].[Stocks] as S
LEFT JOIN [dbo].[Products] as P ON
P.Id = S.ProductId
WHERE
P.[IsDeleted] = 0