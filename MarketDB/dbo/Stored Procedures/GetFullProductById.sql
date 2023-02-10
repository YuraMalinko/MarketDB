CREATE PROCEDURE [dbo].[GetFullProductById]
@id int
AS
SELECT 
P.[Name], P.[GroupId], S.[Amount],T.[Id],T.[Name],
AVG(CAST(PR.[Score] AS float)) AS AverageScore
FROM [dbo].[Products] AS P
LEFT JOIN [dbo].[TagsProducts] AS TP ON
TP.[ProductId] = P.[Id]
INNER JOIN [dbo].[Tags] AS T ON
T.[Id] = TP.[TagId]
LEFT JOIN [dbo].[Stocks] AS S ON
S.[ProductId] = P.[Id]
LEFT JOIN [dbo].[ProductsReviews] AS PR ON
PR.ProductId = P.[Id]
WHERE
P.[IsDeleted] = 0 AND
T.[IsDeleted] = 0
GROUP BY
P.[Name], P.[GroupId], S.[Amount],T.[Id],T.[Name]
