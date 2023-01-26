CREATE PROCEDURE GetAllProducts
AS
SELECT
[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =0