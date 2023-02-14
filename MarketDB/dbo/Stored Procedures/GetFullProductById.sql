CREATE PROCEDURE [dbo].[GetFullProductById]
@id int
AS
SELECT 
P.[Id],P.[Name], P.[GroupId], G.[Name], S.[Amount],
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
LEFT JOIN [dbo].[Groups] AS G ON
P.[GroupId] = G.[Id] AND G.[IsDeleted] = 0
WHERE
P.[Id] = @id AND
P.[IsDeleted] = 0 
GROUP BY
P.[Id],P.[Name], P.[GroupId], G.[Name], S.[Amount],T.[Id],T.[Name]
