CREATE PROCEDURE [dbo].[GetAllOrdersByClientId]
@ClientId int
AS
	select
	OS.[Id],
	OS.[DateCreate],
	OS.[ComplitionDate],
	M.[Id],
	M.[Login]
from [Orders] as OS
	inner join Managers as M on OS.ManagerId=M.Id
Where OS.IsDeleted<>1 and OS.ClientId=@ClientId
order by [DateCreate] DESC
