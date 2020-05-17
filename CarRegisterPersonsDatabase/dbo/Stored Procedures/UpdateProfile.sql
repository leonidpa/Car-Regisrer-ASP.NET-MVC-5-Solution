-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProfile]
	@ProfileId BIGINT,
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Patronymic NVARCHAR(32) = NULL,
	@PhoneNumber NVARCHAR(32) = NULL,
	@Result BIT OUTPUT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM Profile 
	WHERE 
	Id = @ProfileId
	)
	BEGIN
		SET @Result = 0;
	END

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
	
	UPDATE Profile SET FirstNameId = @FirstNameId, LastNameId = @LastNameId, PatronymicId = @PatronymicId, PhoneNumberId = @PhoneNumberId
	WHERE Id = @ProfileId;

	SET @Result = 1;
END;