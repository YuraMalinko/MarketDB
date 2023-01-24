CREATE TABLE [dbo].[Orders] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [DateCreate]     DATETIME2 (0) NOT NULL,
    [ComplitionDate] DATETIME2 (0) NOT NULL,
    [IsDeleted]       BIT           DEFAULT ('0') NOT NULL,
    [ManagerId]      INT           NOT NULL,
    [ClientId]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [OrdersFKClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [OrdersFKManagerId] FOREIGN KEY ([ManagerId]) REFERENCES [dbo].[Managers] ([Id]) ON UPDATE CASCADE
);

