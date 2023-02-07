CREATE PROCEDURE [dbo].[GetProductById]
@id int
AS
SELECT [Id],[Name],[GroupId]
FROM [dbo].[Products]
WHERE
[Id]=@id AND [IsDeleted] = 0
