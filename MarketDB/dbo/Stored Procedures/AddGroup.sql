CREATE PROCEDURE [dbo].[AddGroup]
@name nvarchar(100)
AS
INSERT 
	[Groups] ([Name])
VALUES
	(@name)
SELECT
	@@IDENTITY
