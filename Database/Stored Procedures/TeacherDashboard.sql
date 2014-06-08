USE LMS
GO

CREATE PROCEDURE GetSectionsFor
(
	@UserId nvarchar(128)
) AS


--selects the tables 
SELECT  c.CourseName, s.SectionId, count(sc.StudentId) as StudentCount, s.IsArchived
FROM Teacher 
INNER JOIN Section s
ON teacher.TeacherId = s.TeacherId
INNER JOIN Course c
ON s.CourseId = c.CourseId
INNER JOIN StudentSection sc
ON s.SectionId = sc.SectionId
WHERE UserId = @UserId
GROUP BY c.CourseName, s.SectionId, s.IsArchived


EXEC GetSectionsFor @UserId = '750621f5-cfdd-4ee9-b55a-4ada1a33d9fb';
