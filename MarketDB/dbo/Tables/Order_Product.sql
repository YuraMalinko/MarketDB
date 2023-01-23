CREATE TABLE [dbo].[Order_Product] (
    [Id]                  INT             IDENTITY (1, 1) NOT NULL,
    [Count_Products]      INT             NOT NULL,
    [Product_evaluation]  INT             NULL,
    [Comment_For_Product] NVARCHAR (4000) NULL,
    [Is_Delete]           BIT             DEFAULT ('0') NOT NULL,
    [Order_Id]            INT             NOT NULL,
    [Product_Id]          INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Comment_For_Product]<>''),
    CHECK ([Count_Products]>=(0)),
    CHECK ([Product_evaluation]>=(0) AND [Product_evaluation]<=(5)),
    CONSTRAINT [Order_Product_fk_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Order] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [Order_Product_fk_Product_Id] FOREIGN KEY ([Product_Id]) REFERENCES [dbo].[Product] ([Id]) ON UPDATE CASCADE
);

