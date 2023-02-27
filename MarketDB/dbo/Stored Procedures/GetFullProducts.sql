CREATE PROCEDURE [dbo].[GetFullProducts]
AS
SELECT 
P.[Id],P.[Name], P.[GroupId], G.[Name] AS GroupName, S.[Amount],
AVG(CAST(t1.[Score] AS float)) AS AverageScore, T.[Id],T.[Name]
FROM [dbo].[Products] AS P
LEFT JOIN [dbo].[TagsProducts] AS TP ON
TP.[ProductId] = P.[Id]
LEFT JOIN [dbo].[Tags] AS T ON
T.[Id] = TP.[TagId] AND T.[IsDeleted] = 0
LEFT JOIN [dbo].[Stocks] AS S ON
S.[ProductId] = P.[Id]
LEFT JOIN [dbo].[Groups] AS G ON
P.[GroupId] = G.[Id] AND G.[IsDeleted] = 0
LEFT JOIN 
(SELECT *
FROM [dbo].[ProductsReviews] AS PR 
INNER JOIN [dbo].[Clients] AS C ON
PR.[ClientId] = C.[Id] AND C.[IsDeleted] = 0) AS t1
ON
t1.[ProductId] = P.[Id]
WHERE
P.[IsDeleted] = 0 
GROUP BY
P.[Id],P.[Name], P.[GroupId], G.[Name], S.[Amount],T.[Id],T.[Name]
ORDER BY AVG(CAST(t1.[Score] AS float))DESC, P.[Id]
