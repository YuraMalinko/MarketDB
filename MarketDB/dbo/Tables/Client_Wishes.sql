CREATE TABLE [dbo].[Client_Wishes] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [Is_Liked]  BIT NOT NULL,
    [Is_Delete] BIT DEFAULT ('0') NOT NULL,
    [Group_Id]  INT NULL,
    [Tag_Id]    INT NULL,
    [Client_Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Group_Id] IS NOT NULL OR [Tag_Id] IS NOT NULL),
    CONSTRAINT [Client_Wishes_fk_Group_Id] FOREIGN KEY ([Group_Id]) REFERENCES [dbo].[Group] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [Client_Wishes_fk_Tag_Id] FOREIGN KEY ([Tag_Id]) REFERENCES [dbo].[Tag] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [ClientWishes_fk_Client_Id] FOREIGN KEY ([Client_Id]) REFERENCES [dbo].[Client] ([Id]) ON UPDATE CASCADE
);

