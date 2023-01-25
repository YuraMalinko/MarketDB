create Procedure [dbo].[DeleteManagerById]
	@IdManager int
as
	update Managers
	set [IsDeleted] = 1
	where [Id]=@IdManager and [IsDeleted] != 1
