CREATE PROCEDURE [dbo].[AddCommentForOrder]
@Text NVARCHAR(1000),
@OrderId INT
AS
INSERT [dbo].[CommentsForOrders](
[Text],[OrderId],[IsDeleted])
VALUES (@Text,@OrderId,0)
SELECT @@IDENTITY