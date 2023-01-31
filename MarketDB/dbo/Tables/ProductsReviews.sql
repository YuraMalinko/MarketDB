CREATE TABLE [dbo].[ProductsReviews] (
    [ClientId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [Score] INT,
    [Comment] nvarchar (1000),
    CHECK ([Score] IS NOT NULL OR [Comment] IS NOT NULL),
    CONSTRAINT [ProductsReviewsFKClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [ProductsReviewsFKProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON UPDATE CASCADE
);

