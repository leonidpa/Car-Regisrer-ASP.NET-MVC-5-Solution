-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPhoneNumber]
	@PhoneNumber NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM PhoneNumber WHERE Number = @PhoneNumber)
	BEGIN
		INSERT INTO PhoneNumber (Number)
		VALUES (@PhoneNumber);
	END;
END;