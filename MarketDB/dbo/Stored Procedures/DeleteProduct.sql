CREATE PROCEDURE DeleteProduct
@id int
AS
UPDATE [dbo].[Products]
SET
[IsDeleted] = 1
WHERE
[IsDeleted] = 0 AND [Id] = @id