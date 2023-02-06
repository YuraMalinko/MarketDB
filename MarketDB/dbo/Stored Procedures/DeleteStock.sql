CREATE PROCEDURE [dbo].[DeleteStock]
  @amount int,
  @productId int
  AS
  DELETE [dbo].[Stocks]
  WHERE [Amount] = @amount AND
  [ProductId] = @productId
