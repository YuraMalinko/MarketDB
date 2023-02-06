CREATE PROCEDURE [dbo].[UpdateCommentForClient]
@Id int,
@Text nvarchar (1000),
@ClientId int
AS
UPDATE dbo.[CommentsForClients]
SET 
[Text]=@Text,
[ClientId]=@ClientId
WHERE [Id]=@Id AND [IsDeleted]=0