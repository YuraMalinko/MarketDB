CREATE PROCEDURE UpdateProductsName
@id int,
@name nvarchar(100)
AS
UPDATE [dbo].[Products]
SET
[Name]=@name
WHERE
[IsDeleted] = 0 AND Id = @id