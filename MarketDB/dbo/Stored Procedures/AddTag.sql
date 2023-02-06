 CREATE PROCEDURE [dbo].AddTag
  @name nvarchar(100)
  AS
  INSERT INTO [dbo].[Tags] ([Name])
  VALUES (@name)
  SELECT
  SCOPE_IDENTITY()