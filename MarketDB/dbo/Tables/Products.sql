CREATE TABLE [dbo].[Products] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [IsDeleted] BIT            DEFAULT ('0') NOT NULL,
    [GroupId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ProductsFKGroupId] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]) ON UPDATE CASCADE,
    UNIQUE NONCLUSTERED ([Name] ASC)
);

