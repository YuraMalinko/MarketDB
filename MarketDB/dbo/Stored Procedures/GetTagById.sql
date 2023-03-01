CREATE PROCEDURE [dbo].[GetTagById]
  @id int
  AS
  SELECT [Id],[Name]
  FROM [dbo].[Tags]
  WHERE
  [IsDeleted] = 0 AND
  [Id] = @id