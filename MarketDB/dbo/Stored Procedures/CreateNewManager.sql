create procedure dbo.CreateNewManager
	@Login nvarchar (100),
	@Password nvarchar(20)
as
	insert [Managers] values (@Login,@Password,0)