-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [dbo].[DeleteCarModel]
	@CarModelId BIGINT
AS
BEGIN
	DELETE FROM CarModel WHERE Id = @CarModelId;
END;
