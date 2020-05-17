-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCar]
	@CarId BIGINT,
	@OwnerProfileId BIGINT = NULL,
	@CarBrandId BIGINT,
	@CarModelId BIGINT,
	@CarNumber NVARCHAR(16) = NULL,
	@Result BIT OUTPUT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Car 
	WHERE 
	Id = @CarId
	)
	BEGIN
		SET @Result = 0;
	END

	DECLARE @CarNumberId BIGINT;

	IF (@CarNumber <> '' AND @CarNumber IS NOT NULL)
	BEGIN
		EXEC dbo.AddCarNumber @CarNumber = @CarNumber;
		SELECT @CarNumberId = Id FROM CarNumber WHERE Number = @CarNumber;
	END
	
	UPDATE Car SET OwnerProfileId = @OwnerProfileId, BrandId = @CarBrandId, ModelId = @CarModelId, NumberId = @CarNumberId WHERE Id = @CarId;

	SET @Result = 1;
END;
