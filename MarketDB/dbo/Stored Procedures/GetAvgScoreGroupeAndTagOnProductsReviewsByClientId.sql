CREATE PROCEDURE [dbo].[GetAvgScoreGroupeAndTagOnProductsReviewsByClientId]
@Id int
AS
SELECT G.[Id],G.[Name],T.[Id],T.[Name],ROUND(AVG(CAST(PR.Score AS FLOAT)),2) AS AvgScore FROM ProductsReviews AS PR
INNER JOIN Products AS P ON PR.[ProductId]=P.[Id]
INNER JOIN dbo.[Groups] AS G ON P.[GroupId]=G.[Id] and G.[IsDeleted]=0
LEFT JOIN dbo.[TagsProducts] AS TP ON TP.[ProductId]=P.[Id]
LEFT JOIN dbo.[Tags] AS T ON TP.[TagId]=T.[Id] and  T.[IsDeleted]=0
WHERE PR.[ClientId]=@Id
GROUP BY G.[Id],G.[Name],T.[Id],T.[Name]