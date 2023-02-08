CREATE PROCEDURE [dbo].DeleteClientWishesById
  @id int
  AS
  DELETE [dbo].[ClientsWishes]
  WHERE
  [Id] = @id