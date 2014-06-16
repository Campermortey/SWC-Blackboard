ALTER PROCEDURE TeacherGradebookView
(
	@ClassId int
)AS

SELECT u.FirstName, u.LastName, sg.LetterGrade, a.Name, CONVERT(decimal(5, 2),Grade.Score) as [Percent]
FROM AspNetUsers u
	INNER JOIN Roster
	ON u.Id = roster.UserId
	INNER JOIN Grade 
	ON roster.RosterId = Grade.RosterId
	INNER JOIN Assignment a
	ON grade.AssignmentId = a.AssignmentId
	INNER JOIN StudentGrades sg
	ON roster.RosterId = sg.RosterId
WHERE sg.ClassId = @ClassId

EXEC TeacherGradebookView 8