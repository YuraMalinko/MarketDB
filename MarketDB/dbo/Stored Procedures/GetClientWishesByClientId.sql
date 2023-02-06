  CREATE PROCEDURE [dbo].GetClientWishesByClientId
  @clientId int
  AS
  SELECT [Id], [GroupId],[TagId],[IsLiked]
  FROM [dbo].[ClientsWishes]
  WHERE
  [ClientId] = @clientId
