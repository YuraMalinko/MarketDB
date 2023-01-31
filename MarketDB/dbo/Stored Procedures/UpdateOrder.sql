CREATE PROCEDURE [dbo].[UpdateOrder]
	@Id int,
	@DateCreate datetime2,
	@ComplitionDate datetime2,
	@ManagerId int,
	@ClientId int
AS
	Update dbo.Orders
	set
	[DateCreate] = @DateCreate,
	[ComplitionDate]=@ComplitionDate,
	[ManagerId]=@ManagerId,
	[ClientId]=@ClientId
	Where [Id]=@Id