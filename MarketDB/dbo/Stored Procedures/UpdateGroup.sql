CREATE PROCEDURE [dbo].[UpdateGroup]
	@Id int,
	@Name nvarchar(100)
AS
UPDATE 
	Groups
SET
	[Name] = @Name
WHERE 
	[Id]=@Id
