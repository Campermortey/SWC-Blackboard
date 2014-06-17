CREATE PROCEDURE RosterGetStudents (
	@ClassId int
) AS

SELECT r.RosterId, u.FirstName, u.LastName, u.UserName 
FROM Roster r 
	INNER JOIN AspNetUsers u ON r.UserId = u.Id
WHERE r.IsDeleted = 0 AND r.ClassId = @ClassId

GO