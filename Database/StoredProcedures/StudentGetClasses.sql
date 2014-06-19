CREATE PROCEDURE StudentGetClasses
(
	@UserId nvarchar(128)
)AS

--Selects the name and letter grade for a particular student
SELECT c.Name, sg.LetterGrade, c.ClassId, R.RosterId
FROM AspNetUsers u
	INNER JOIN Roster r
	ON u.Id = r.UserId
	INNER JOIN Class c
	ON r.ClassId = c.ClassId
	INNER JOIN StudentGrades sg
	ON r.RosterId = sg.RosterId
WHERE u.Id = @UserId
