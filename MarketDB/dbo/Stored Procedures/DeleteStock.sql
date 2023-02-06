CREATE PROCEDURE [dbo].[DeleteStock]
  @amount int,
  @productId int
  AS
  delete [dbo].[Stocks]
  Where [Amount] = @amount AND
  [ProductId] = @productId
