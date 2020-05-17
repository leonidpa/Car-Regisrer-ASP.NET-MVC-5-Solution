-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProfile]
	@ProfileId BIGINT
AS
BEGIN
	DELETE FROM Profile WHERE Id = @ProfileId;
END;