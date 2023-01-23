CREATE TABLE [dbo].[Comment_For_Order] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (4000) NULL,
    [Is_Delete] BIT             DEFAULT ('0') NOT NULL,
    [Order_Id]  INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Text]<>''),
    CONSTRAINT [Comment_For_Order_fk_Order_Id] FOREIGN KEY ([Order_Id]) REFERENCES [dbo].[Order] ([Id]) ON UPDATE CASCADE
);

