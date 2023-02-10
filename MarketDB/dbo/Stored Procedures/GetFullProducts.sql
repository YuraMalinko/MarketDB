CREATE PROCEDURE [dbo].[GetFullProducts]
AS
SELECT 
P.[Id],P.[Name], P.[GroupId], S.[Amount],
AVG(CAST(PR.[Score] AS float)) AS AverageScore, T.[Id],T.[Name]
FROM [dbo].[Products] AS P
LEFT JOIN [dbo].[TagsProducts] AS TP ON
TP.[ProductId] = P.[Id]
LEFT JOIN [dbo].[Tags] AS T ON
T.[Id] = TP.[TagId] AND T.[IsDeleted] = 0
LEFT JOIN [dbo].[Stocks] AS S ON
S.[ProductId] = P.[Id]
LEFT JOIN [dbo].[ProductsReviews] AS PR ON
PR.ProductId = P.[Id]
WHERE
P.[IsDeleted] = 0 
GROUP BY
P.[Id],P.[Name], P.[GroupId], S.[Amount],T.[Id],T.[Name]
ORDER BY AVG(CAST(PR.[Score] AS float))DESC, P.[Id]
