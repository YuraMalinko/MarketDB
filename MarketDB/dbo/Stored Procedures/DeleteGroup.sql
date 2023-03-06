CREATE PROCEDURE [dbo].[DeleteGroup]
  @id int
  AS
  UPDATE [dbo].[Groups]
  SET [IsDeleted] = 1
  WHERE
  [Id] = @Id