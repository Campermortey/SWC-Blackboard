ALTER PROCEDURE RosterSearchByLastName (
	@ClassId int,
	@LastName nvarchar(25)
) AS
SELECT u.FirstName, u.LastName, u.GradeLevel, u.Id AS UserId
FROM AspNetUsers u 
	INNER JOIN AspNetUserRoles ur on u.Id = ur.UserId
	INNER JOIN AspNetRoles ro ON ur.RoleId = ro.Id
WHERE ro.Name='Student' 
	AND u.Id NOT IN (SELECT UserId FROM Roster WHERE ClassId = @ClassId)
	 AND u.LastName LIKE @LastName + '%'

GO


ALTER PROCEDURE RosterSearchByLastNameAndGradeLevel (
	@ClassId int,
	@LastName nvarchar(25),
	@GradeLevel tinyint
) AS
SELECT u.FirstName, u.LastName, u.GradeLevel, u.Id AS UserId
FROM AspNetUsers u 
	INNER JOIN AspNetUserRoles ur on u.Id = ur.UserId
	INNER JOIN AspNetRoles ro ON ur.RoleId = ro.Id
WHERE ro.Name='Student' 
	AND u.Id NOT IN (SELECT UserId FROM Roster WHERE ClassId = @ClassId) 
	AND u.LastName LIKE @LastName + '%'
	AND u.GradeLevel = @GradeLevel

GO

ALTER PROCEDURE RosterSearchByGradeLevel (
	@ClassId int,
	@GradeLevel tinyint
) AS
SELECT u.FirstName, u.LastName, u.GradeLevel, u.Id AS UserId
FROM AspNetUsers u 
	INNER JOIN AspNetUserRoles ur on u.Id = ur.UserId
	INNER JOIN AspNetRoles ro ON ur.RoleId = ro.Id
WHERE ro.Name='Student' 
	AND u.Id NOT IN (SELECT UserId FROM Roster WHERE ClassId = @ClassId) 
	AND u.GradeLevel = @GradeLevel

GO
