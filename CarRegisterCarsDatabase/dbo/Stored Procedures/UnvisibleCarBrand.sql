-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UnvisibleCarBrand]
	@CarBrandId BIGINT
AS
BEGIN
	UPDATE CarBrand SET Visibility = 0 WHERE Id = @CarBrandId;
END;
