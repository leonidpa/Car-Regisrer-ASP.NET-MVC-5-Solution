-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCar]
	@OwnerProfileId BIGINT = NULL,
	@CarBrandId BIGINT,
	@CarModelId BIGINT,
	@CarNumber NVARCHAR(16) = NULL,
	@ResultCarId BIGINT OUTPUT
AS
BEGIN
	DECLARE @CarNumberId BIGINT;

	IF (@CarNumber <> '' AND @CarNumber IS NOT NULL)
	BEGIN
		EXEC dbo.AddCarNumber @CarNumber = @CarNumber;
		SELECT @CarNumberId = Id FROM CarNumber WHERE Number = @CarNumber;
	END
	
	IF NOT EXISTS (SELECT * FROM Car 
	WHERE 
	BrandId = @CarBrandId AND
	ModelId = @CarModelId AND
	NumberId = @CarNumberId AND
	OwnerProfileId = @OwnerProfileId
	)
	BEGIN
		INSERT INTO Car(BrandId, ModelId, NumberId, OwnerProfileId)
		VALUES (@CarBrandId, @CarModelId, @CarNumberId, @OwnerProfileId);
		SET @ResultCarId = IDENT_CURRENT('Car');
	END
	ELSE
	BEGIN
		SELECT @ResultCarId = Id FROM Car 
	WHERE 
	BrandId = @CarBrandId AND
	ModelId = @CarModelId AND
	NumberId = @CarNumberId AND
	OwnerProfileId = @OwnerProfileId
	END
END;
