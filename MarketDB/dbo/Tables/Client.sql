CREATE TABLE [dbo].[Client] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (100) NOT NULL,
    [Tel_Number] NVARCHAR (20)  NULL,
    [Is_Delete]  BIT            DEFAULT ('0') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Name]<>'')
);

