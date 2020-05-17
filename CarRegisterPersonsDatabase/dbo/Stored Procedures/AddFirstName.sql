-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddFirstName]
	@FirstName NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM FirstName WHERE Name = @FirstName)
	BEGIN
		INSERT INTO FirstName (Name)
		VALUES (@FirstName);	
	END;
END;
	