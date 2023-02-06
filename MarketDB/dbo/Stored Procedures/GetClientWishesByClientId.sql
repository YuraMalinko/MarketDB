  CREATE PROCEDURE [dbo].GetClientWishesByClientId
  @clientId int
  AS
  SELECT [GroupId],[TagId],[IsLiked]
  FROM [dbo].[ClientsWishes]
  WHERE
  [ClientId] = @clientId
