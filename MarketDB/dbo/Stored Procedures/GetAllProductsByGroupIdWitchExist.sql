CREATE PROCEDURE [dbo].[GetAllProductsByGroupIdWitchExist]
@groupId int
AS
SELECT
P.[Id], P.[Name], G.Id
FROM [dbo].[Products] AS P
INNER JOIN [dbo].[Groups] AS G
ON
P.[GroupId]=G.[Id] AND G.[IsDeleted]=0
WHERE P.[IsDeleted]=0 AND G.[IsDeleted]=0 AND
G.[Id] = @groupId