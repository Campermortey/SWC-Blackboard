CREATE PROCEDURE InsertScoreIntoAssignment
(
	@AssignmentId int,
	@RosterId int,
	@Points int
) AS


declare @possiblePoints int
declare @score decimal(5,2)

SELECT @PossiblePoints = PossiblePoints
FROM Assignment WHERE AssignmentId = @AssignmentId

SET @Score = Cast(@Points as decimal(5,2)) / cast(@possiblePoints as decimal);
print @Score

INSERT INTO [Grade] (RosterId, AssignmentId, Points, Score)
VALUES (@RosterId, @AssignmentId, @Points, @Score)
