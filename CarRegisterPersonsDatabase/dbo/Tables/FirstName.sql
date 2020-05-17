CREATE TABLE [dbo].[FirstName] (
    [Id]   BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_FirstName] PRIMARY KEY CLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[FirstName]([Id] ASC);

