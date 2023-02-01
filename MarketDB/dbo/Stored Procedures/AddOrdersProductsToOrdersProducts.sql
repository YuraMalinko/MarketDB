CREATE PROCEDURE [dbo].[AddOrdersProductsToOrdersProducts]
@orderId int,
@productId int,
@countProduct int
AS
INSERT INTO [dbo].[OrdersProducts] ([OrderId],[ProductId],[CountProduct])
VALUES (@orderId, @productId, @countProduct)

