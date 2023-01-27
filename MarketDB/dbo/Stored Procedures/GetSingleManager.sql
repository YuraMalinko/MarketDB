create procedure dbo.GetSingleManager
	@Login nvarchar(100),
	@Password nvarchar(20)
as
	select [Id],[Login],[Password] from Managers
	Where (([Login] = @Login) and ([Password]=@Password))