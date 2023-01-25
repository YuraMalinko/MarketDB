create procedure dbo.GetAllIsNotDeleteManager
as
	select [Id],[Login] from Managers
	where [IsDeleted] = 0