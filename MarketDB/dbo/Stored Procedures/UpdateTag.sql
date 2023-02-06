CREATE PROCEDURE [dbo].UpdateTag
  @id int,
  @name nvarchar(100)
  AS
  UPDATE [dbo].[Tags]
  SET
  [Name] = @name
  WHERE
  [IsDeleted] = 0 AND
  [Id] = @id