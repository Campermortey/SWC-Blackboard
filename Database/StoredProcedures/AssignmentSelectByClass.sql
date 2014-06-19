ALTER PROCEDURE AssignmentSelectByClass(
	@ClassId int
) AS

SELECT AssignmentId, ClassId, Name, PossiblePoints, DueDate, [Description]
FROM Assignment
WHERE ClassID = @ClassId
ORDER BY DueDate


EXEC AssignmentSelectByClass 8