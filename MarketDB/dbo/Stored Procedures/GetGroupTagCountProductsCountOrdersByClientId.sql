CREATE PROCEDURE [dbo].[GetGroupTagCountProductsCountOrdersByClientId]
@clientId int
  AS						
  SELECT 
  CAST(SUM(OP.[CountProduct]) AS FLOAT) AS CountProducts,CAST(COUNT(DISTINCT OP.[OrderId]) AS FLOAT)AS CountOrders,G.[Id] as GroupId,T.[Id] AS TagId
  FROM [dbo].[TagsProducts] AS TP       
  INNER JOIN [dbo].[Tags] AS T ON       
  TP.[TagId] = T.[Id] AND T.[IsDeleted] = 0       
  RIGHT JOIN [dbo].[Products] AS P ON       
  P.[Id] = TP.[ProductId]       
  INNER JOIN [dbo].[Groups] AS G ON       
  P.[GroupId] = G.[Id] AND G.[IsDeleted] = 0 
  INNER JOIN [dbo].[OrdersProducts] AS OP ON 
  OP.[ProductId] = P.[Id] 
  INNER JOIN  [dbo].[Orders] AS O ON 
  O.[Id] = OP.[OrderId] AND O.[IsDeleted] = 0 
  INNER JOIN [dbo].[Clients] AS C ON 
  O.[ClientId]=C.[Id] AND C.[IsDeleted] =0 
  WHERE O.[ClientId] = @clientId
  GROUP BY G.[Id],T.[Id]