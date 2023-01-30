create procedure dbo.AddManager
	@Login nvarchar (100),
	@Password nvarchar(20)
as
	insert [Managers] ([Login],[Password],[IsDeleted]) values (@Login,@Password,0)
SELECT @@IDENTITY;