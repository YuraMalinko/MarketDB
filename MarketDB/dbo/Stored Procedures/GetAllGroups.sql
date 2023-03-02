CREATE PROCEDURE [dbo].GetAllGroups
AS
SELECT [Id],[Name]
FROM [dbo].[Groups]
WHERE [IsDeleted] =0