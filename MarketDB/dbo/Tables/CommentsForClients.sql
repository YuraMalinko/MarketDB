CREATE TABLE [dbo].[CommentsForClients] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Text]      NVARCHAR (1000) NOT NULL,
    [IsDeleted] BIT             DEFAULT ('0') NOT NULL,
    [ClientId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CommentsForClientsFKClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON UPDATE CASCADE
);