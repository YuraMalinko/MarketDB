CREATE PROCEDURE [dbo].[AddClient]
@Name nvarchar(100),
@PhoneNumber nvarchar(20)
AS
INSERT [dbo].[Clients] ([Name],[PhoneNumber],[IsDeleted])
VALUES (@Name,@PhoneNumber,0)
SELECT @@IDENTITY