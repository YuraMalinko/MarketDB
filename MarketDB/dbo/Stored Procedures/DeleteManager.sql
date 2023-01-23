create Procedure [dbo].[DeleteManager]
	@IdManager int
as
	update Manager
	set [Is_Delete] = 1
	where [Id]=@IdManager and [Is_Delete] != 1
