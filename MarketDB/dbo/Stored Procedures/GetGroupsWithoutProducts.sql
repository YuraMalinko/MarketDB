CREATE PROCEDURE [dbo].[GetGroupsWithoutProducts]
AS
SELECT G.[Id], G.[Name]
FROM [dbo].[Groups] AS G
LEFT JOIN [dbo].[Products] AS P
ON P.[GroupId]=G.[Id]
WHERE G.[IsDeleted]=0 AND 
P.[Id] is null