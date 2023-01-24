CREATE PROCEDURE GetAllProducts
AS
SELECT
[Id], [Name], [Count], [Group_Id]
FROM
[dbo].[Product]
WHERE
[Is_Delete] =0
