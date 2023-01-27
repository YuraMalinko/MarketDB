create procedure dbo.GetAllManagers
as
	select [Id],[Login] from Managers
	where [IsDeleted] = 0