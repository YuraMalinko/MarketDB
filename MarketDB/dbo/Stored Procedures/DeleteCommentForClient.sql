CREATE PROCEDURE [dbo].[DeleteCommentForClient]
@Id int
AS
UPDATE [CommentsForClients]
SET [IsDeleted]=1
WHERE [Id]=@Id
