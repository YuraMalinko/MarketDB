CREATE PROCEDURE AddProduct
@name nvarchar(100),
@groupId int
AS
INSERT INTO [dbo].[Products] ([Name],[GroupId])
VALUES
(@name, @groupId)