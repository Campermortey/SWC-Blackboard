CREATE PROCEDURE AssignmentSelectByClass(
	@ClassId int
) AS

SELECT AssignmentId, ClassId, Name, PossiblePoints, DueDate, [Description]
FROM Assignment
WHERE ClassID = @ClassId