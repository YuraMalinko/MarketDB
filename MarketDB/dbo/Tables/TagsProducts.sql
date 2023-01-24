CREATE TABLE [dbo].[TagsProducts] (
    [TagId]     INT NOT NULL,
    [ProductId] INT NOT NULL,
    CONSTRAINT [TagsProductsFKProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [TagsProductsFKTagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id]) ON UPDATE CASCADE
);

