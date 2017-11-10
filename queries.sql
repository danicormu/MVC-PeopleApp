CREATE PROCEDURE Insert_user(
 @Username varchar(50),
 @Name varchar(50),
 @Surname1 varchar(50),
 @Surname2 varchar(50),
 @Phone varchar(50),
 @Address1 varchar(70),
 @Active bit
 )
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		INSERT INTO signupDB.dbo.Users (Username,Name,Surname1,Surname2,Phone,Address1,Active)
		VALUES(@Username,@Name,@Surname1,@Surname2,@Phone,@Address1,@Active)
	END
END


CREATE PROCEDURE RetrieveAll_user
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		SELECT *
		FROM signupDB.dbo.Users
	END
END

CREATE PROCEDURE RetrieveById_user(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		SELECT *
		FROM signupDB.dbo.Users
		WHERE Id = @id
	END
END

CREATE PROCEDURE Delete_user
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		DELETE FROM signupDB.dbo.Users
	END
END

CREATE PROCEDURE Update_user(
 @Id int,
 @Username varchar(50),
 @Name varchar(50),
 @Surname1 varchar(50),
 @Surname2 varchar(50),
 @Phone varchar(50),
 @Address1 varchar(70),
 @Active bit
 )
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		UPDATE signupDB.dbo.Users
		SET Username = @Username, Name = @Name, Surname1 = @Surname1, Surname2 = @surname2,
		Phone = @Phone, Address1 = @Address1, Active = @Active
		WHERE Id = @Id
	END
END

CREATE PROCEDURE DeleteByID_user(
	@id int
)
AS
BEGIN
	SET NOCOUNT ON
	BEGIN
		DELETE FROM signupDB.dbo.Users
		WHERE Id = @id
	END
END
