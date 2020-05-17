-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarBrandModels]
	@BrandId BIGINT
AS
BEGIN
	SELECT CarModel.Id, CarModel.Name
	FROM 
		(SELECT * FROM CarBrandModel WHERE BrandId = @BrandId) AS SelectedBrand
		INNER JOIN CarModel ON SelectedBrand.ModelId = CarModel.Id
	WHERE Visibility = 1
	ORdER BY CarModel.Name ASC;
END;
