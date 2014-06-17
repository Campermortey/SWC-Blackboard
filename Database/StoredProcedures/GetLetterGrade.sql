CREATE PROCEDURE GetLetterGrade
(
	@ClassId int,
	@RosterId int
)AS

SELECT RosterId,  LetterGrade
FROM StudentGrades
WHERE ClassId = @ClassId AND RosterId = @RosterId