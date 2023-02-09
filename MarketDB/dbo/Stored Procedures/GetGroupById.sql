CREATE PROCEDURE [dbo].GetGroupById
@id int
AS
SELECT [Id],[Name]
FROM [dbo].[Groups]
WHERE [IsDeleted] =0 AND
[Id] = @id
