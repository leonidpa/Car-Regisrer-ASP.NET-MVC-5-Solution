-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddProfile]
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Patronymic NVARCHAR(32) = NULL,
	@PhoneNumber NVARCHAR(32) = NULL,
	@ResultProfileId BIGINT OUTPUT
AS
BEGIN
	DECLARE @FirstNameId BIGINT;
	DECLARE @LastNameId BIGINT;
	DECLARE @PatronymicId BIGINT;
	DECLARE @PhoneNumberId BIGINT;

	EXEC dbo.AddFirstName @FirstName = @FirstName;
	SELECT @FirstNameId = Id FROM FirstName WHERE Name = @FirstName;

	EXEC dbo.AddLastName @LastName = @LastName;
	SELECT @LastNameId = Id FROM LastName WHERE Name = @LastName;

	IF (@Patronymic <> '' AND @Patronymic IS NOT NULL)
	BEGIN
		EXEC dbo.AddPatronymic @Patronymic = @Patronymic;
		SELECT @PatronymicId = Id FROM Patronymic WHERE Name = @Patronymic;
	END
	IF (@PhoneNumber <> '' AND @PhoneNumber IS NOT NULL)
	BEGIN
		EXEC dbo.AddPhoneNumber @PhoneNumber = @PhoneNumber;
		SELECT @PhoneNumberId = Id FROM PhoneNumber WHERE Number = @PhoneNumber;
	END
	
	IF NOT EXISTS (SELECT * FROM Profile 
	WHERE 
	FirstNameId = @FirstNameId AND
	LastNameId = @LastNameId AND
	PatronymicId = @PatronymicId AND
	PhoneNumberId = @PhoneNumberId
	)
	BEGIN
		INSERT INTO Profile (FirstNameId, LastNameId, PatronymicId, PhoneNumberId)
		VALUES (@FirstNameId, @LastNameId, @PatronymicId, @PhoneNumberId);
		SET @ResultProfileId = IDENT_CURRENT('Profile');
	END
	ELSE
	BEGIN
		SELECT @ResultProfileId = Id FROM Profile 
		WHERE 
		FirstNameId = @FirstNameId AND
		LastNameId = @LastNameId AND
		PatronymicId = @PatronymicId AND
		PhoneNumberId = @PhoneNumberId
	END
END;