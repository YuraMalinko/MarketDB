CREATE PROCEDURE [dbo].[GetClientsWhoOrderedProductByProductId]
@productId int
AS
SELECT
C.[Id], C.[Name], C.[PhoneNumber], P.[Id], P.[Name]
FROM [dbo].[OrdersProducts] AS OP
INNER JOIN [dbo].[Products] AS P ON
P.[Id] = OP.[ProductId]
LEFT JOIN [dbo].[Orders] AS O ON
O.[Id] = OP.[OrderId]
LEFT JOIN [dbo].[Clients] AS C ON
C.[Id] = O.[ClientId]
WHERE
P.[IsDeleted] =0 AND
C.[IsDeleted] = 0 AND
P.[Id] = @productId
GROUP BY C.[Id], C.[Name], C.[PhoneNumber],  P.[Id], P.[Name]
