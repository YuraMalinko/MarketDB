CREATE PROCEDURE [dbo].UpdateClientWishes
  @clientId int,
  @groupId int,
  @tagId int,
  @isLiked bit
  AS
  UPDATE [dbo].[ClientsWishes]
  SET
  [GroupId]=@groupId,
  [TagId]=@tagId,
  [IsLiked]=@isLiked
  WHERE
  [ClientId] = @clientId
