CREATE PROCEDURE [dbo].[AddCommentForClient]
@Text NVARCHAR(1000),
@ClientId INT
AS
INSERT dbo.[CommentsForClients](
[Text],[ClientId],[IsDeleted])
VALUES (@Text,@ClientId,0)
SELECT @@IDENTITY