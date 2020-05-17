-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetProfiles]
AS
BEGIN
	SELECT Profile.Id, FirstName.Name AS FirstName, LastName.Name AS LastName, Patronymic.Name AS Patronymic, PhoneNumber.Number AS PhoneNumber
	FROM Profile
	LEFT JOIN FirstName ON Profile.FirstNameId = FirstName.Id
	LEFT JOIN LastName ON Profile.LastNameId = LastName.Id
	LEFT JOIN Patronymic ON Profile.PatronymicId = Patronymic.Id
	LEFT JOIN PhoneNumber ON Profile.PhoneNumberId = PhoneNumber.Id
	ORDER BY Profile.Id DESC;
END;
	