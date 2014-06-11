ALTER PROCEDURE RosterDeleteStudent(
	@ClassId int,
	@UserId nvarchar(128)
) AS

Update Roster
	SET IsDeleted = 1
WHERE UserId = @UserId AND ClassId = @ClassId