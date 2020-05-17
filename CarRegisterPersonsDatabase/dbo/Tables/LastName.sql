CREATE TABLE [dbo].[LastName] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_LastName] PRIMARY KEY CLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[LastName]([Id] ASC);

