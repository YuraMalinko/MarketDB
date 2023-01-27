create Procedure dbo.UpdateManager
	@IdManager int,
	@NewLogin nvarchar(100),
	@NewPassword nvarchar(20)
as
	update Managers
	set	[Login] = @NewLogin,
		[Password] = @NewPassword
	where [Id]=@IdManager