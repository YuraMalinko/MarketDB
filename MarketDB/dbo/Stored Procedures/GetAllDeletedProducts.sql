CREATE PROCEDURE GetAllDeletedProducts
AS
SELECT
[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =1