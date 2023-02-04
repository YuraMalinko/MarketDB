CREATE PROCEDURE [dbo].[GetAllClients]
AS
SELECT
C.[Id],
C.[Name],
C.[PhoneNumber],
CFC.[Id],
CFC.[Text]
FROM [Clients] AS C
LEFT JOIN [CommentsForClients] as CFC on C.Id=CFC.ClientId AND CFC.IsDeleted=0
WHERE C.[IsDeleted]=0