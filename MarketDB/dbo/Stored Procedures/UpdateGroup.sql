 CREATE PROCEDURE [dbo].[UpdateGroup]
  @id int,
  @name nvarchar(100)
  AS
  UPDATE [dbo].[Groups]
  SET
  [Name] = @name
  WHERE
  [IsDeleted] = 0 AND
  [Id] = @id