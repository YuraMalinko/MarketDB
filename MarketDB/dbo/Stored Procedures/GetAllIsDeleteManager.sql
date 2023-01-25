create procedure dbo.GetAllIsDeleteManager
as
	select [Id],[Login] from Managers
	where [IsDeleted] = 1