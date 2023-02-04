CREATE PROCEDURE [dbo].[DeleteClient]
@Id int
AS
UPDATE [Clients]
SET [IsDeleted]=1
WHERE [Id]=@Id
