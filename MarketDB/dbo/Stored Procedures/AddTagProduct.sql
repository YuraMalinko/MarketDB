CREATE PROCEDURE [dbo].AddTagProduct
@tagId int,
@productId int
AS
INSERT INTO [dbo].[TagsProducts] ([TagId],[ProductId])
VALUES (@tagId, @productId)