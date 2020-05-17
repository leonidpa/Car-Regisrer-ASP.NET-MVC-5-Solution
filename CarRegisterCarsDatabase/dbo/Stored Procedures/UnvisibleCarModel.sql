-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UnvisibleCarModel]
	@CarModelId BIGINT
AS
BEGIN
	UPDATE CarModel SET Visibility = 0 WHERE Id = @CarModelId;
END;
