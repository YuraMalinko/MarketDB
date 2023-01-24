CREATE PROCEDURE AddProduct
@name nvarchar(100),
@count int,
@groupedId int
AS
INSERT INTO [dbo].[Product] ([Name],[Count],[Group_Id])
VALUES
(@name, @count, @groupedId)