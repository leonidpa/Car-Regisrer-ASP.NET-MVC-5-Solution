CREATE TABLE [dbo].[DisplayProfileModels] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (MAX) NULL,
    [LastName]      NVARCHAR (MAX) NULL,
    [Patronymic]    NVARCHAR (MAX) NULL,
    [PhoneNumber]   NVARCHAR (MAX) NULL,
    [Discriminator] NVARCHAR (128) NOT NULL,
    CONSTRAINT [PK_dbo.DisplayProfileModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

