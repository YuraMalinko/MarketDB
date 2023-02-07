  CREATE PROCEDURE [dbo].[DeleteTagProduct]
  @tagId int,
  @productId int
  AS
  delete [dbo].[TagsProducts]
  Where [TagId] = @tagId AND
  [ProductId] = @productId