-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarBrands]
AS
BEGIN
	SELECT Id, Name
	FROM CarBrand 
	WHERE Visibility = 1
	ORDER BY Name ASC;
END;
