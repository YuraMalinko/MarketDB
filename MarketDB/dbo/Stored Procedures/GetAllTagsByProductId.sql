CREATE PROCEDURE [dbo].GetAllTagsByProductId
  @productId int
  AS
  SELECT T.[Id], T.[Name]
  FROM [dbo].[TagsProducts] AS TP
  LEFT JOIN [dbo].[Tags] AS T ON
  T.[Id] = TP.[TagId]
  LEFT JOIN [dbo].[Products] AS P ON
  TP.[ProductId] = P.[Id]
  WHERE
  T.[IsDeleted] = 0 AND
  P.[IsDeleted] = 0 AND
  TP.[ProductId] = @productId
