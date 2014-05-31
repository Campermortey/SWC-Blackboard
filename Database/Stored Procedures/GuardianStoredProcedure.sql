USE LMS
GO

CREATE PROCEDURE GardianInsert
(
	@UserId int,
	@FirstName varchar(20),
	@LastName varchar(50),
	@Email varchar(40)
)AS

INSERT INTO Guardian(UserId, FirstName, LastName, Email)
VALUES (@UserId, @FirstName, @LastName, @Email)

GO

CREATE PROCEDURE GuardianUpdate
(
	@GuardianId int,
	@UserId int,
	@FirstName varchar(20),
	@LastName varchar(50),
	@Email varchar(40)
)AS

UPDATE Guardian
	SET UserId = @UserId,
	FirstName = @FirstName,
	LastName = @LastName,
	Email = @Email
WHERE GuardianId = @GuardianId

GO

CREATE PROCEDURE GuardianDelete
(
	@GuardianId int
)AS

DELETE FROM Guardian
WHERE GuardianId = @GuardianId

GO