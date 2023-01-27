create Procedure [dbo].[DeleteManager]
	@IdManager int
as
	update Managers
	set [IsDeleted] = 1
	where [Id]=@IdManager and [IsDeleted] != 1
