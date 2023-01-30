CREATE PROCEDURE UpdateProduct
@id int,
@name nvarchar(100),
@groupId int
AS
UPDATE [dbo].[Products]
SET
[Name]=@name,
[GroupId] = @groupId
WHERE
[IsDeleted] = 0 AND Id = @id