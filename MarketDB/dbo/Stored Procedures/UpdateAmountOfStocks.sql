CREATE PROCEDURE UpdateAmountOfStocks
@productId int,
@amount int
AS
Update [dbo].[Stocks]
SET
[Amount] = @amount
WHERE
[ProductId] = @productId