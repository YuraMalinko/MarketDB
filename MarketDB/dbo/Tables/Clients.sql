CREATE TABLE [dbo].[Clients] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [PhoneNumber] NVARCHAR (20)  NOT NULL,
    [IsDeleted]  BIT            DEFAULT ('0') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
);