-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProfile]
	@ProfileId BIGINT
AS
BEGIN
	SELECT SelectedProfile.Id, FirstName.Name AS FirstName, LastName.Name AS LastName, Patronymic.Name AS Patronymic, PhoneNumber.Number AS PhoneNumber
	FROM (SELECT * FROM Profile WHERE Id = @ProfileId) AS SelectedProfile
	LEFT JOIN FirstName ON SelectedProfile.FirstNameId = FirstName.Id
	LEFT JOIN LastName ON SelectedProfile.LastNameId = LastName.Id
	LEFT JOIN Patronymic ON SelectedProfile.PatronymicId = Patronymic.Id
	LEFT JOIN PhoneNumber ON SelectedProfile.PhoneNumberId = PhoneNumber.Id;
END;
	