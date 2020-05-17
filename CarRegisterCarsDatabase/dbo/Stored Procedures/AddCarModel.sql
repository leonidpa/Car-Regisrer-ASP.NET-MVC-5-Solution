-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCarModel]
	@CarBrandId BIGINT,
	@CarModelName NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM CarModel WHERE Name = @CarModelName)
	BEGIN
		INSERT INTO CarModel (Name)
		VALUES (@CarModelName);	
	END
	ELSE
	BEGIN
		UPDATE CarModel SET Visibility = 1 WHERE Name = @CarModelName;
	END;
	
	IF EXISTS (SELECT * FROM CarBrand WHERE Id = @CarBrandId)
	BEGIN
		DECLARE @CarModelId BIGINT;
		SELECT @CarModelId = Id FROM CarModel WHERE Name = @CarModelName;
		IF NOT EXISTS (SELECT * FROM CarBrandModel WHERE BrandId = @CarBrandId AND ModelId = @CarModelId)
		BEGIN
			INSERT INTO CarBrandModel (BrandId, ModelId) VALUES (@CarBrandId, @CarModelId);
		END
	END;
	
END;
