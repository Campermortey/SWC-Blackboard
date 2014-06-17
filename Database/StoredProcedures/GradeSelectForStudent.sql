CREATE PROCEDURE GradesSelectForStudent(
	@RosterId int,
	@ClassId int
) AS

SELECT g.RosterId, a.AssignmentId, g.Points, g.Score, a.PossiblePoints 
FROM Assignment a
	INNER JOIN Grade g ON a.AssignmentId = g.AssignmentId
WHERE RosterId = @RosterId AND a.ClassId = @ClassId

UNION

SELECT @RosterId as RosterId, a.AssignmentId, null as Points, null as Score, a.PossiblePoints 
FROM Assignment a 
WHERE AssignmentId NOT IN (SELECT AssignmentId FROM Grade WHERE RosterId = @RosterId) AND ClassId = @ClassId
