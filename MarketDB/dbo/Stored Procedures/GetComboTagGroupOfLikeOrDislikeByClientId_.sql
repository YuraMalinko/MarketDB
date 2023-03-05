CREATE PROCEDURE [dbo].[GetComboTagGroupOfLikeOrDislikeByClientId]
@ClientId int
AS
SELECT CW.[IsLiked],G.[Id] as GroupId,T.[Id] AS TagId FROM dbo.[ClientsWishes] AS CW
LEFT JOIN dbo.[Groups] AS G ON CW.[GroupId]=G.[Id]
LEFT JOIN dbo.[Tags] AS T ON CW.[TagId]=T.[Id]
WHERE CW.[ClientId]=@ClientId
AND (G.[IsDeleted] = 0 or G.[Id] is null)
AND (T.[IsDeleted] = 0 or T.[Id] is null)