create procedure dbo.GetManagerByIdAndPassword
	@Login nvarchar(100)
as
	select [Id],[Login],[Password] from Managers
	Where [Login] = @Login