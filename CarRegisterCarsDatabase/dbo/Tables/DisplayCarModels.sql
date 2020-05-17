CREATE TABLE [dbo].[DisplayCarModels] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [OwnerProfileId] BIGINT         NULL,
    [Brand]          NVARCHAR (MAX) NULL,
    [Model]          NVARCHAR (MAX) NULL,
    [Number]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.DisplayCarModels] PRIMARY KEY CLUSTERED ([Id] ASC)
);

