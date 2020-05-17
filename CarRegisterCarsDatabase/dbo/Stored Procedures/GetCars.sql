-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCars]
AS
BEGIN
	SELECT Car.Id, Car.OwnerProfileId, CarBrand.Name AS Brand, CarModel.Name AS Model, CarNumber.Number AS Number
	FROM Car 
	LEFT JOIN CarBrand ON Car.BrandId = CarBrand.Id
	LEFT JOIN CarModel ON Car.ModelId = CarModel.Id
	LEFT JOIN CarNumber ON Car.NumberId = CarNumber.Id
	ORDER BY Car.Id DESC;
END;
