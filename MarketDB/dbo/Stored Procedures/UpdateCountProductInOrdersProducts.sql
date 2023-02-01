CREATE PROCEDURE [dbo].[UpdateCountProductInOrdersProducts]
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
