CREATE PROCEDURE [dbo].[DeleteGroup]
	@Id int
AS
	UPDATE Groups
SET
	[IsDeleted] = 1
WHERE
	[Id]=@Id
