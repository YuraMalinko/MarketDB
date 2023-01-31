CREATE PROCEDURE GetAllProductsByGroupId
@groupId int
AS
SELECT
[Id],[Name], [GroupId]
FROM
[dbo].[Products]
WHERE
[IsDeleted] =0 AND GroupId = @groupId