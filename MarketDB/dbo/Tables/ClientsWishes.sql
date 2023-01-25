CREATE TABLE [dbo].[ClientsWishes] (
    [IsLiked]  BIT NOT NULL,
    [GroupId]  INT NULL,
    [TagId]    INT NULL,
    [ClientId] INT NOT NULL,
    CHECK ([GroupId] IS NOT NULL OR [TagId] IS NOT NULL),
    CONSTRAINT [ClientsWishesFKGroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [ClientsWishesFKTagId] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tags] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [ClientsWishesFKClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([Id]) ON UPDATE CASCADE
);