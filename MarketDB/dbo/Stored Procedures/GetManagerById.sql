CREATE PROCEDURE [dbo].[GetManagerById]
@id int
AS
SELECT [Id],[Login] FROM [Managers]
WHERE [Id]=@id AND [IsDeleted]=0
