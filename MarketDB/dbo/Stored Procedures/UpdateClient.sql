CREATE PROCEDURE [dbo].[UpdateClient]
@Id int,
@Name nvarchar (100),
@PhoneNumber nvarchar(20)
AS
UPDATE [Clients] 
SET [Name] = @Name,
[PhoneNumber] = @PhoneNumber
WHERE [Id]=@Id AND [IsDeleted]=0