CREATE TABLE [dbo].[Car] (
    [Id]             BIGINT IDENTITY (1, 1) NOT NULL,
    [BrandId]        BIGINT NOT NULL,
    [ModelId]        BIGINT NOT NULL,
    [NumberId]       BIGINT NULL,
    [OwnerProfileId] BIGINT NULL,
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Car_CarBrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[CarBrand] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Car_CarModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[CarModel] ([Id]),
    CONSTRAINT [FK_Car_CarNumberId] FOREIGN KEY ([NumberId]) REFERENCES [dbo].[CarNumber] ([Id])
);

