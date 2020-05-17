CREATE TABLE [dbo].[Profile] (
    [Id]            BIGINT IDENTITY (1, 1) NOT NULL,
    [FirstNameId]   BIGINT NOT NULL,
    [LastNameId]    BIGINT NOT NULL,
    [PatronymicId]  BIGINT NULL,
    [PhoneNumberId] BIGINT NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Profile_FirstNameId] FOREIGN KEY ([FirstNameId]) REFERENCES [dbo].[FirstName] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Profile_LastNameId] FOREIGN KEY ([LastNameId]) REFERENCES [dbo].[LastName] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Profile_PatronymicId] FOREIGN KEY ([PatronymicId]) REFERENCES [dbo].[Patronymic] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Profile_PhoneNumberId] FOREIGN KEY ([PhoneNumberId]) REFERENCES [dbo].[PhoneNumber] ([Id]) ON UPDATE CASCADE
);

