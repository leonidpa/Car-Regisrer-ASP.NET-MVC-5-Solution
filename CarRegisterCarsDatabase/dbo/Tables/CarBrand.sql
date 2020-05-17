CREATE TABLE [dbo].[CarBrand] (
    [Id]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (32) NOT NULL,
    [Visibility] BIT           CONSTRAINT [DF_CarBrand_Visibility] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_CarBrand] PRIMARY KEY CLUSTERED ([Name] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [U_Id]
    ON [dbo].[CarBrand]([Id] ASC);

