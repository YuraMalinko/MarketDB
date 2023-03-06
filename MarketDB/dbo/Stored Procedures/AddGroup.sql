CREATE PROCEDURE [dbo].[AddGroup]
  @name nvarchar(100)
  AS
  INSERT INTO [dbo].[Groups] ([Name])
  VALUES (@name)
  SELECT
  SCOPE_IDENTITY()