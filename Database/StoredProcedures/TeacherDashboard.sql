USE SWC_LMS
GO

CREATE PROCEDURE ClassSummaryGetList
(
	@UserId nvarchar(128)
) AS

SELECT c.ClassId, c.Name, c.IsArchived, count(r.ClassId) as NumberOfStudents
FROM Class c
INNER JOIN Roster r
ON c.ClassId = r.ClassId
WHERE c.UserId = @UserId
GROUP BY c.ClassId, c.Name, c.IsArchived

