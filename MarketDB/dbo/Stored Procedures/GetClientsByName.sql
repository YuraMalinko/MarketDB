CREATE PROCEDURE [dbo].[GetClientsByName]
@Name nvarchar(100)
AS
SELECT [Id],[Name],[PhoneNumber] FROM [Clients]
WHERE [Name]=@Name And [IsDeleted]=0