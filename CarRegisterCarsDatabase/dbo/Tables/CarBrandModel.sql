CREATE TABLE [dbo].[CarBrandModel] (
    [BrandId] BIGINT NOT NULL,
    [ModelId] BIGINT NOT NULL,
    CONSTRAINT [PK_CarBrandModel] PRIMARY KEY CLUSTERED ([BrandId] ASC, [ModelId] ASC),
    CONSTRAINT [FK_CarBrandModel_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[CarBrand] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_CarBrandModel_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[CarModel] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);

