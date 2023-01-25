create procedure dbo.CreateNewManager
	@Name nvarchar (100),
	@Password nvarchar(20)
as
	insert [Managers] values (@Name,@Password,0)