CREATE TABLE [dbo].[Managers] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Login]     NVARCHAR (100) NOT NULL,
    [Password]  NVARCHAR (20)  NOT NULL,
    [IsDeleted] BIT            DEFAULT ('0') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC)
);

