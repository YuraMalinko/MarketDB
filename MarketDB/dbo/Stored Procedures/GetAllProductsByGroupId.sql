CREATE PROCEDURE GetAllProductsByGroupId
@groupId int
AS
SELECT
[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =0 AND GroupId = @groupId