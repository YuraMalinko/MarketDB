CREATE PROCEDURE [dbo].[UpdateCountInOrdersProducts]
  @orderId int,
  @productId int,
  @countProduct int
  AS
  UPDATE [dbo].[OrdersProducts]
  SET
  [CountProduct] = @countProduct
  WHERE
  [OrderId] = @orderId AND
  [ProductId] = @productId
