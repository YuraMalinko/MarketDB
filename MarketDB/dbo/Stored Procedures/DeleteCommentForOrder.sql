CREATE PROCEDURE [dbo].[DeleteCommentForOrder]
@Id int
AS
UPDATE [dbo].[CommentsForOrders]
SET [IsDeleted]=1
WHERE [Id]=@Id