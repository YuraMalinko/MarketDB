Create Procedure [dbo].[GetAllOrdersByIdManager]
@ManagerId int
as
	select
	OS.[Id],
	OS.[DateCreate],
	OS.[ComplitionDate],
	CL.[Id],
	CL.[Name]
from [Orders] as OS
	inner join Clients as CL on OS.ClientId=CL.Id
Where OS.IsDeleted!=1 and OS.ManagerId=@ManagerId
order by [DateCreate] DESC