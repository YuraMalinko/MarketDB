create Procedure [dbo].[DeleteManager]
	@Id int
as
	update Managers
	set [IsDeleted] = 1
	where [Id]=@Id and [IsDeleted] != 1
