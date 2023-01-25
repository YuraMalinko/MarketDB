create Procedure dbo.UpdatePasswordManager
	@IdManager int,
	@NewPassword nvarchar(20)
as
	update Managers
	set [Password] = @NewPassword
	where [Id]=@IdManager
