create procedure dbo.GetAllManagers
as
	select [Id],[Login],[Password] from Managers
	where [IsDeleted] = 0