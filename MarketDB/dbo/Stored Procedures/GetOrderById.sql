  CREATE PROCEDURE [dbo].GetOrderById
  @id int
  AS
  SELECT [Id],[DateCreate],[ComplitionDate],[ManagerId], [ClientId]
  FROM [dbo].[Orders]
  WHERE
  [Id] = @id AND
  [IsDeleted] = 0