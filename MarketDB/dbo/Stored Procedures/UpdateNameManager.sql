create Procedure UpdateNameManager
	@IdManager int,
	@NewLogin nvarchar(100)
as
	update Manager
	set [Login] = @NewLogin
	where [Id]=@IdManager