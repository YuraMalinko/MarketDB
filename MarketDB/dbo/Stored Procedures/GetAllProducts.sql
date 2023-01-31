CREATE PROCEDURE GetAllProducts
AS
SELECT
[Id],[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =0