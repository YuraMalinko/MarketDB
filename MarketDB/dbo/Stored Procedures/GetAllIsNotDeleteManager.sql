create procedure dbo.GetAllManagerIsNotDelete
as
	select [Id],[Login] from Manager
	where [Is_Delete] = 0