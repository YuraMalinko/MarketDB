  CREATE PROCEDURE [dbo].[GetAllProductsInOrderByOrderId]
  @orderId int
  AS
  SELECT
  O.[Id] AS OrderId, O.[DateCreate], O.[ComplitionDate], M.[Id] AS ManagerId, M.[Login], CMN.[Text], 
  C.[Id] AS ClientId, C.[Name] AS ClientName,  C.[PhoneNumber], P.[Id] AS ProductId, P.[Name]  AS ProductName, OP.[CountProduct]
  FROM [dbo].[Orders] AS O
  LEFT JOIN [dbo].[OrdersProducts] AS OP ON
  OP.[OrderId] =O.[Id]
  LEFT JOIN [dbo].[Products] AS P ON
  OP.[ProductId] =P.[Id]
  LEFT JOIN [dbo].[Clients] AS C ON
  O.[ClientId] = C.[Id]
  LEFT JOIN [dbo].[CommentsForOrders] AS CMN ON
  O.[Id] = CMN.[OrderId]
  LEFT JOIN [dbo].[Managers] AS M ON
  M.Id = O.ManagerId
  WHERE
  OP.[OrderId] = @orderId AND
  O.[IsDeleted] =0
