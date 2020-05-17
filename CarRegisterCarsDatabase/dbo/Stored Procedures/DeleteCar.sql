-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCar]
	@CarId BIGINT
AS
BEGIN
	DELETE FROM Car WHERE Id = @CarId;
END;
