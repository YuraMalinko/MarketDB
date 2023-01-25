CREATE PROCEDURE GetAmountByProductId
@productId int
AS
SELECT [ProductId],[Amount]
FROM [dbo].[Stocks]
WHERE
[ProductId]=@productId