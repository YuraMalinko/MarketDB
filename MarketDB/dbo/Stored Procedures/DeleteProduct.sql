CREATE PROCEDURE DeleteProduct
@id int
AS
UPDATE [dbo].[Product]
SET
[Is_Delete] = 1
WHERE
[Is_Delete] = 0 AND [Id] = @id