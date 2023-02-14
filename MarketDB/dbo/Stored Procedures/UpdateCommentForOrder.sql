CREATE PROCEDURE [dbo].[UpdateCommentForOrder]
@Id int,
@Text nvarchar (1000),
@OrderId int
AS
UPDATE [dbo].[CommentsForOrders]
SET 
[Text]=@Text,
[OrderId]=@OrderId
WHERE [Id]=@Id AND [IsDeleted]=0