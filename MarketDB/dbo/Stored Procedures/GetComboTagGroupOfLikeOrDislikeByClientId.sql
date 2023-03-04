CREATE PROCEDURE [dbo].[GetComboTagGroupOfLikeOrDislikeByClientId]
@ClientId int
AS
SELECT CW.[IsLiked],G.[Id] ,G.[Name],T.[Id],T.[Name] FROM dbo.[ClientsWishes] AS CW
LEFT JOIN dbo.[Groups] AS G ON CW.[GroupId]=G.[Id]
LEFT JOIN dbo.[Tags] AS T ON CW.[TagId]=T.[Id]
WHERE CW.[ClientId]=@ClientId
AND (G.[IsDeleted] = 0 or G.[IsDeleted] is null)
AND (T.[IsDeleted] = 0 or T.[IsDeleted] is null) 