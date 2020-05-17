-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCar]
	@CarId BIGINT
AS
BEGIN
	SELECT SelectedCar.Id, SelectedCar.OwnerProfileId, CarBrand.Name AS Brand, CarModel.Name AS Model, CarNumber.Number AS Number
	FROM (SELECT * FROM Car WHERE Id = @CarId) AS SelectedCar
	LEFT JOIN CarBrand ON SelectedCar.BrandId = CarBrand.Id
	LEFT JOIN CarModel ON SelectedCar.ModelId = CarModel.Id
	LEFT JOIN CarNumber ON SelectedCar.NumberId = CarNumber.Id;
END;
