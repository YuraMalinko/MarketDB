CREATE PROCEDURE GetAllProducts
AS
SELECT
[Name], [Count], [Group_Id]
FROM
[dbo].[Product]
WHERE
[Is_Delete] =0
