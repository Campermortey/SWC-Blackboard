CREATE VIEW AssignmentGrade
AS

SELECT RosterId, Grade.AssignmentId, Name, Score, CASE
	WHEN (100.*Score)<60 THEN 'F'
	WHEN (100.*Score)<70 THEN 'D'
	WHEN (100.*Score)<80 THEN 'C'
	WHEN (100.*Score)<90 THEN 'B'
	WHEN (100.*Score)<=100 THEN 'A'
END AS LetterGrade

FROM Grade
	INNER JOIN Assignment
	ON grade.AssignmentId = Assignment.AssignmentId
