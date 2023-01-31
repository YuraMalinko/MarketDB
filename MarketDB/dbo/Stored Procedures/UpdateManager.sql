create Procedure dbo.UpdateManager
	@Id int,
	@Login nvarchar(100),
	@Password nvarchar(20)
as
	update Managers
	set [Login] = @Login,
		[Password] = @Password
	where [Id]=@Id