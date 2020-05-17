-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPatronymic]
	@Patronymic NVARCHAR(32)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Patronymic WHERE Name = @Patronymic)
	BEGIN
		INSERT INTO Patronymic (Name)
		VALUES (@Patronymic);
	END;
END;
	