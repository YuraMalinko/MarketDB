CREATE PROCEDURE [dbo].AddClientWishes
  @clientId int,
  @groupId int,
  @tagId int,
  @isLiked bit
  AS
  INSERT INTO [dbo].[ClientsWishes] 
  ([ClientId],[GroupId],[TagId],[IsLiked])
  VALUES
  (@clientId, @groupId, @tagId,  @isLiked)
