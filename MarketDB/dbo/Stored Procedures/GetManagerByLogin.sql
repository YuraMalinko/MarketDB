CREATE PROCEDURE [dbo].[GetManagerByLogin]
@Login nvarchar (100)
AS
SELECT [Id],[Login] FROM [Managers]
WHERE [Login]=@Login AND [IsDeleted]=0