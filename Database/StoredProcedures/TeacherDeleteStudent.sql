CREATE PROCEDURE RosterDeleteStudent(
	@ClassId int,
	@UserId nvarchar(128)
) AS

DELETE FROM Roster
WHERE UserId = @UserId AND ClassId = @ClassId