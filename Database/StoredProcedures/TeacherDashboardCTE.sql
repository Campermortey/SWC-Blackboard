
with ClassCounts AS (
	SELECT ClassId, Count(*) AS NumberOfStudents
	FROM Roster
	GROUP BY ClassId
)
SELECT c.ClassId, c.Name, c.IsArchived, ISNULL(NumberOfStudents, 0) AS NumberOfStudents
FROM Class c
LEFT JOIN ClassCounts cc ON c.ClassId = cc.ClassId
WHERE c.UserId = '4043b572-3a35-48fd-8b8e-3cf511d9560a'
