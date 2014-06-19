CREATE PROCEDURE StudentAssignmentGetGrades
(
	@RosterId int
)AS

SELECT AssignmentId, Name, Score, LetterGrade
FROM AssignmentGrade
WHERE RosterId = @RosterId