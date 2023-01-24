create procedure dbo.GetAllIsDeleteManager
as
	select [Id],[Login] from Manager
	where [Is_Delete] = 1