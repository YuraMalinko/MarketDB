CREATE PROCEDURE [dbo].GetClientByPhoneNumber
@PhoneNumber NVARCHAR
AS
SELECT [Id],[Name]
FROM [dbo].[Clients]
WHERE [IsDeleted] =0 AND [PhoneNumber] = @PhoneNumber