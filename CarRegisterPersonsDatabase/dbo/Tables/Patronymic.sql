CREATE TABLE [dbo].[Patronymic] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_Patronymic] PRIMARY KEY CLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[Patronymic]([Id] ASC);

