USE LMS
GO

CREATE PROCEDURE GetSectionsFor
(
	@UserId nvarchar(128)
) AS


--selects the tables 
SELECT  c.CourseName, s.SectionId, count(sc.StudentId) as StudentCount, s.IsArchived
FROM Section s
INNER JOIN Course c
ON s.CourseId = c.CourseId
INNER JOIN StudentSection sc
ON s.SectionId = sc.SectionId
GROUP BY c.CourseName, s.SectionId, s.IsArchived

EXEC GetSectionsFor @UserId = '064df794-b4e7-41ed-ba1e-529cec36d924';
