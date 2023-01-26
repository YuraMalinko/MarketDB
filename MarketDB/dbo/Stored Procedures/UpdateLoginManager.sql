create Procedure dbo.UpdateLoginManager
	@IdManager int,
	@NewLogin nvarchar(100)
as
	update Managers
	set [Login] = @NewLogin
	where [Id]=@IdManager