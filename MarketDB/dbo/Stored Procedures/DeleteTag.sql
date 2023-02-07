CREATE PROCEDURE [dbo].DeleteTag
  @id int
  AS
  UPDATE [dbo].[Tags]
  SET [IsDeleted] = 1
  WHERE
  [Id] = @Id
