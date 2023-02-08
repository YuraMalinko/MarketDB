CREATE PROCEDURE [dbo].UpdateClientWishesById
  @id int,
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
  [Id] = @id
