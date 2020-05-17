-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCarBrand]
	@CarBrandId BIGINT
AS
BEGIN
	DELETE FROM CarBrand WHERE Id = @CarBrandId;
END;
