create procedure [dbo].[DeleteOrder]
	@Id int
as
	Update dbo.Orders set [IsDeleted] = 1
	Where [Id]=@Id