CREATE PROCEDURE GetAllIsNotDeletedProducts
AS
SELECT
[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =0