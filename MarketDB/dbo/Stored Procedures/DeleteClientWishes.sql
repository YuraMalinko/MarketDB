CREATE PROCEDURE [dbo].DeleteClientWishes
  @clientId int,
  @groupId int,
  @tagId int
  AS
  DELETE [dbo].[ClientsWishes]
  WHERE
  [ClientId] = @clientId AND
  [GroupId]=@groupId AND
  [TagId]=@tagId