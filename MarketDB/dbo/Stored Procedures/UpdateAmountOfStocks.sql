CREATE PROCEDURE UpdateAmountOfStocks
@productId int,
@changeAmount int
AS
Update [dbo].[Stocks]
SET
[Amount] = @changeAmount
WHERE
[ProductId] = @productId