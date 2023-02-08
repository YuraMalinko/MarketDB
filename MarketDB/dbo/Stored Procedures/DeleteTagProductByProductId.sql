CREATE PROCEDURE [dbo].[DeleteTagProductByProductId]
@productId int
AS
DELETE [dbo].[TagsProducts]
WHERE
[ProductId]=@productId
