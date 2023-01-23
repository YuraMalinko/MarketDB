CREATE TABLE [dbo].[Order] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Date_Create]     DATETIME2 (0) NOT NULL,
    [Complition_Date] DATETIME2 (0) NOT NULL,
    [Is_Delete]       BIT           DEFAULT ('0') NOT NULL,
    [Manager_Id]      INT           NOT NULL,
    [Client_Id]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Order_fk_Client_Id] FOREIGN KEY ([Client_Id]) REFERENCES [dbo].[Client] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [Order_fk_Manager_Id] FOREIGN KEY ([Manager_Id]) REFERENCES [dbo].[Manager] ([Id]) ON UPDATE CASCADE
);

