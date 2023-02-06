CREATE PROCEDURE [dbo].[AddProductToOrders]
@orderId int,
@productId int,
@countProduct int
AS
INSERT INTO [dbo].[OrdersProducts] ([OrderId],[ProductId],[CountProduct])
VALUES (@orderId, @productId, @countProduct)

