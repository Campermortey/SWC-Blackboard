ALTER PROCEDURE TeacherGetClassGrades
(
	@ClassId int
)AS

--Returns all the Grades with the count of students
SELECT ll.Letter as LetterGrade, ISNULL(mycount, 0) AS NumberStudents 
FROM ListOfLetters ll
	LEFT JOIN (SELECT sg.LetterGrade , Count(sg.LetterGrade) as mycount, ClassId
				FROM StudentGrades sg 
				WHERE ClassId = @ClassId
				GROUP BY sg.LetterGrade, ClassId
				) table2
				on ll.Letter = table2.LetterGrade
GROUP BY ll.Letter, mycount
