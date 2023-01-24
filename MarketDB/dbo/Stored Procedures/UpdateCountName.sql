CREATE PROCEDURE UpdateCountName
@id int,
@count int
AS
UPDATE [dbo].[Product]
SET
[Count]=@count
WHERE
[Is_Delete] = 0 AND Id = @id
