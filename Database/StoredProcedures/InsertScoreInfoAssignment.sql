ALTER PROCEDURE [dbo].[InsertScoreIntoAssignment]
(
	@AssignmentId int,
	@RosterId int,
	@Points int
) AS


declare @possiblePoints int
declare @Score decimal(5,2)

--you need the possible points
SELECT @PossiblePoints = PossiblePoints
FROM Assignment WHERE AssignmentId = @AssignmentId

SET @Score = Cast(@Points as decimal(5,2)) / cast(@possiblePoints as decimal);
print @Score

IF Exists(SELECT * FROM Grade WHERE RosterId = @RosterId AND AssignmentId = @AssignmentId)
BEGIN
	-- update
	UPDATE [Grade] 
	SET Score = @Score,
	Points = @Points
WHERE AssignmentId = @AssignmentId AND RosterId = @RosterId
END
ELSE

BEGIN
	INSERT INTO [Grade] (AssignmentId, RosterId, Points, Score)
	VALUES (@AssignmentId, @RosterId, @Points, @Score)
END