CREATE PROCEDURE [dbo].[GetAllPurchasedProductsByClientId]
@Id int
AS
SELECT 
P.[Id],
P.[Name],
SUM(OP.[CountProduct]) as AmountOrderedByCustomer,
G.[Id],
G.[Name],
T.[Id],
T.[Name]
FROM dbo.[Orders] AS O
INNER JOIN dbo.[OrdersProducts] AS OP ON O.[Id]=OP.[OrderId]
INNER JOIN dbo.[Products] AS P ON OP.[ProductId]=P.[Id]
INNER JOIN dbo.[Groups] AS G ON P.[GroupId]=G.[Id]
LEFT JOIN dbo.[TagsProducts] AS TP ON TP.[ProductId]=P.[Id]
LEFT JOIN dbo.[Tags] AS T ON TP.[TagId]=T.[Id]
WHERE (O.[ClientId]=@Id)
GROUP BY P.[Id],P.[Name],G.[Id],G.[Name],T.[Id],T.[Name]
ORDER BY AmountOrderedByCustomer DESC