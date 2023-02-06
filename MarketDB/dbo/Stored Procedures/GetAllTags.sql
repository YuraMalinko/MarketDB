CREATE PROCEDURE [dbo].[GetAllTags]
  AS
  SELECT [Id],[Name]
  FROM [dbo].[Tags]
  WHERE
  [IsDeleted] = 0
