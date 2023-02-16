CREATE PROCEDURE [dbo].GetProductsStatistic
AS
SELECT t1.[Id], t1.[Name], ISNULL (t1.[SumOfCountofProduct], 0) AS SumOfCountofProduct, 
t1.[CountOfOrders], t1.[CountOfClients], AVG(CAST(PR.[Score] AS float)) AS AverageScore
FROM
(SELECT P.[Id], P.[Name], SUM(OP.[CountProduct]) AS SumOfCountofProduct,
COUNT(OP.[OrderId]) AS CountOfOrders, COUNT(DISTINCT O.[ClientId]) AS CountOfClients
FROM [dbo].[Products] AS P
LEFT JOIN [dbo].[OrdersProducts] AS OP ON
P.[Id] = OP.[ProductId]  
LEFT JOIN [dbo].[Orders] AS O ON
OP.[OrderId] = O.[Id] AND O.[IsDeleted] = 0
WHERE
P.[IsDeleted] = 0 
GROUP BY P.[Id], P.[Name]
) AS t1
LEFT JOIN [dbo].[ProductsReviews] AS PR ON
t1.[Id] = PR.[ProductId]
GROUP BY t1.[Id], t1.[Name], t1.[SumOfCountofProduct],
t1.[CountOfOrders], t1.[CountOfClients] 
ORDER BY t1.[SumOfCountofProduct] DESC
