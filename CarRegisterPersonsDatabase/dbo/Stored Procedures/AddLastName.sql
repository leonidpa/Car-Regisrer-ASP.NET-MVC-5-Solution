-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddLastName]
	@LastName NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM LastName WHERE Name = @LastName)
	BEGIN
		INSERT INTO LastName (Name)
		VALUES (@LastName);	
	END;
END;
	