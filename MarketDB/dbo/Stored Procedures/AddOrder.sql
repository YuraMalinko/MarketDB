create procedure dbo.AddOrder
	@DateCreate datetime2(0),
	@ComplitionDate datetime2(0),
	@ManagerId int,
	@ClientId int
as
	insert [Orders] 
	([DateCreate],[ComplitionDate],[IsDeleted],[ManagerId],[ClientId])
	values
	(@DateCreate,@ComplitionDate,0,@ManagerId,@ClientId)