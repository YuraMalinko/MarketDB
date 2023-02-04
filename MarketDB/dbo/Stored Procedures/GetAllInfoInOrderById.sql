  CREATE PROCEDURE [dbo].[GetAllInfoInOrderById]
  @orderId int
  AS
  SELECT
  O.[Id] AS OrderId, O.[DateCreate], O.[ComplitionDate], CMN.[Text] AS Comment, M.[Id], M.[Login], 
  C.[Id], C.[Name],  C.[PhoneNumber], P.[Id] AS ProductId, P.[Name]  AS ProductName, OP.[CountProduct]
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
