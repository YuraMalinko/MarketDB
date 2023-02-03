CREATE PROCEDURE [dbo].[GetAllGroups]
AS
SELECT 
	[Id],[Name] from Groups
WHERE 
	[IsDeleted] = 0
