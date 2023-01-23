CREATE TABLE [dbo].[Comment_For_Client] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (4000) NOT NULL,
    [Is_Delete] BIT             DEFAULT ('0') NOT NULL,
    [Client_Id] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Text]<>''),
    CONSTRAINT [Comment_For_Client_fk_Client_Id] FOREIGN KEY ([Client_Id]) REFERENCES [dbo].[Client] ([Id]) ON UPDATE CASCADE
);

