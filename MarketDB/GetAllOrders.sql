CREATE PROCEDURE [dbo].[GetAllOrders]
as
select
	OS.[Id],
	OS.[DateCreate],
	OS.[ComplitionDate],
	CL.[Id],
	CL.[Name],
	M.[Id],
	M.[Login]
from [Orders] as OS
	inner join Managers as M on OS.ManagerId=M.Id
	inner join Clients as CL on OS.ClientId=CL.Id
Where OS.IsDeleted!=1
order by [DateCreate] DESC