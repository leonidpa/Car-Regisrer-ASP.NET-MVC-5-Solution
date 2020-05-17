CREATE TABLE [dbo].[CarNumber] (
    [Id]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [Number] NVARCHAR (16) NOT NULL,
    CONSTRAINT [PK_CarNumber] PRIMARY KEY CLUSTERED ([Number] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[CarNumber]([Id] ASC);

