CREATE PROCEDURE GetAmountByProductId
@productId int
AS
SELECT P.[Id] AS [ProductId],P.[Name] , ISNULL (S.[Amount], 0) AS [Amount]
FROM [dbo].[Products] as P 
LEFT JOIN [dbo].[Stocks] as S ON
P.Id = S.ProductId
WHERE
P.[Id]=@productId AND
P.[IsDeleted] = 0