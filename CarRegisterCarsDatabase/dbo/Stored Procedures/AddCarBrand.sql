-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCarBrand]
	@CarBrandName NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM CarBrand WHERE Name = @CarBrandName)
	BEGIN
		INSERT INTO CarBrand (Name)
		VALUES (@CarBrandName);	
	END
	ELSE
	BEGIN
		UPDATE CarBrand SET Visibility = 1 WHERE Name = @CarBrandName;
	END;
END;
