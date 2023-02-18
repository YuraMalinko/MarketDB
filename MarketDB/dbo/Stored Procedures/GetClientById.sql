 CREATE PROCEDURE [dbo].GetClientById
  @id int
  AS
  SELECT [Id],[Name],[PhoneNumber]
  FROM [dbo].[Clients]
  WHERE
  [Id] = @id AND
  [IsDeleted] = 0
