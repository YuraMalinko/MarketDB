CREATE PROCEDURE [dbo].[GetAvgScoreGroupeAndTagOnProductsReviewsByClientId]
@ClientId int
AS
SELECT ROUND(AVG(CAST(ISNULL(PR.Score,3) AS FLOAT)),1) AS AvgScore ,G.[Id],G.[Name],T.[Id],T.[Name]
FROM dbo.[ProductsReviews] AS PR
INNER JOIN Products AS P ON PR.[ProductId]=P.[Id]
INNER JOIN dbo.[Groups] AS G ON P.[GroupId]=G.[Id] and G.IsDeleted=0
LEFT JOIN dbo.[TagsProducts] AS TP ON TP.[ProductId]=P.[Id]
LEFT JOIN dbo.[Tags] AS T ON TP.[TagId]=T.[Id]
WHERE PR.[ClientId]=@ClientId and (T.[IsDeleted] = 0 or T.[IsDeleted] is null)
GROUP BY G.[Id],G.[Name],T.[Id],T.[Name]
ORDER BY AvgScore DESC