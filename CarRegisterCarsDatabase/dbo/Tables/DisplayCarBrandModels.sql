CREATE TABLE [dbo].[DisplayCarBrandModels] (
    [Id]         BIGINT         IDENTITY (1, 1) NOT NULL,
    [Visibility] BIT            NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.DisplayCarBrandModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

