CREATE TABLE [dbo].[Product] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NOT NULL,
    [Count]     INT            NOT NULL,
    [Is_Delete] BIT            DEFAULT ('0') NOT NULL,
    [Group_Id]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Count]>=(0)),
    CHECK ([Name]<>''),
    CONSTRAINT [Product_fk_Group_Id] FOREIGN KEY ([Group_Id]) REFERENCES [dbo].[Group] ([Id]) ON UPDATE CASCADE,
    UNIQUE NONCLUSTERED ([Name] ASC)
);

