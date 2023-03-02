CREATE PROCEDURE [dbo].[DeleteTagByProductIdAndTagId]
@productId int,
@tagId int
AS
DELETE [dbo].[TagsProducts]
WHERE
[ProductId]=@productId AND
[TagId] = @tagId