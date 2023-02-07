CREATE PROCEDURE [dbo].[AddAmountToStocks]
@productId int,
@amount int
AS
INSERT INTO [dbo].[Stocks] ([Amount],[ProductId])  
VALUES (@amount, @productId)
SELECT [Amount],[ProductId]
FROM [Stocks]
INNER JOIN Products AS P ON
[Stocks].ProductId = P.ID
WHERE
P.IsDeleted=0