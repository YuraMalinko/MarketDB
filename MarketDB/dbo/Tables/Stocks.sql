CREATE TABLE [dbo].[Stocks] (
    [Amount] INT NOT NULL,
    [ProductId] INT NOT NULL,
    CONSTRAINT [StocksFKProductsId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON UPDATE CASCADE,
);
