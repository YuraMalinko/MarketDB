CREATE PROCEDURE GetAllProductsByGroupId
@group_Id int
AS
SELECT
[Id], [Name], [Count], [Group_Id]
FROM
[dbo].[Product]
WHERE
[Is_Delete] =0 AND Group_Id = @group_Id