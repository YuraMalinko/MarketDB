CREATE PROCEDURE UpdateProductName
@id int,
@name nvarchar(100)
AS
UPDATE [dbo].[Product]
SET
[Name]=@name
WHERE
[Is_Delete] = 0 AND Id = @id