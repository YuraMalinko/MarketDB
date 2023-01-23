CREATE TABLE [dbo].[Manager] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Login]     NVARCHAR (100) NOT NULL,
    [Password]  NVARCHAR (20)  NOT NULL,
    [Is_Delete] BIT            DEFAULT ('0') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC)
);

