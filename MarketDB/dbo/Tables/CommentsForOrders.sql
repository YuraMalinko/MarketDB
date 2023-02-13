CREATE TABLE [dbo].[CommentsForOrders] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (1000) NOT NULL,
    [IsDeleted] BIT             DEFAULT ('0') NOT NULL,
    [OrderId]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CommentsForOrdersFKOrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id]) ON UPDATE CASCADE
);