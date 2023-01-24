create procedure dbo.GetSpecificManager
	@Login nvarchar(100)
as
	select [Id],[Login],[Password] from Manager
	Where [Login] = @Login