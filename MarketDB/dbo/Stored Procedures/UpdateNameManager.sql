create Procedure dbo.UpdateNameManager
	@IdManager int,
	@NewLogin nvarchar(100)
as
	update Managers
	set [Login] = @NewLogin
	where [Id]=@IdManager