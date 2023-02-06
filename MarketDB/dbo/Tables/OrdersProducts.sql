CREATE TABLE [dbo].[OrdersProducts] (
    [OrderId]            INT             NOT NULL,
    [ProductId]          INT             NOT NULL,
    [CountProduct]      INT             NOT NULL,
    CHECK ([CountProduct]>=(0)),
    CONSTRAINT [OrdersProductsFKOrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [OrdersProductsFKProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Products] ([Id]) ON UPDATE CASCADE
);

