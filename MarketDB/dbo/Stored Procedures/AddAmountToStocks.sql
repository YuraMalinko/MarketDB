CREATE PROCEDURE AddAmountToStocks
@productId int,
@amount int
AS
INSERT INTO [dbo].[Stocks] ([Amount],[ProductId])
VALUES (@amount, @productId)