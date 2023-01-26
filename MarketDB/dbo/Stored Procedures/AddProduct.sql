CREATE PROCEDURE AddProduct
@name nvarchar(100),
@groupedId int
AS
INSERT INTO [dbo].[Products] ([Name],[GroupId])
VALUES
(@name, @groupedId)