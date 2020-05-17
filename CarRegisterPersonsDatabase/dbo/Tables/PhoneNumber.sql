CREATE TABLE [dbo].[PhoneNumber] (
    [Id]     BIGINT        IDENTITY (1, 1) NOT NULL,
    [Number] NVARCHAR (32) NOT NULL,
    CONSTRAINT [PK_PhoneNumber] PRIMARY KEY CLUSTERED ([Number] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[PhoneNumber]([Id] ASC);

