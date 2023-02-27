CREATE PROCEDURE [dbo].GetCommentsForClientById
@clientId int
AS
SELECT [Id], [Text]
FROM [dbo].[CommentsForClients]
WHERE
[ClientId] = @clientId And [IsDeleted]=0
