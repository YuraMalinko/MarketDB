create procedure dbo.GetAllManagerIsNotDelete
as
	select [Id],[Login] from Managers
	where [IsDeleted] = 0