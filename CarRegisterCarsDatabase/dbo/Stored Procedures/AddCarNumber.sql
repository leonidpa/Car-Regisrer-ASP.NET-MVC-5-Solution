-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCarNumber]
	@CarNumber NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM CarNumber WHERE Number = @CarNumber)
	BEGIN
		INSERT INTO CarNumber (Number)
		VALUES (@CarNumber);	
	END;
END;
