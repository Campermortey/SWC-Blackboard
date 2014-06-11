USE SWC_LMS
GO

CREATE PROCEDURE ClassSummaryGetList
(
	@UserId nvarchar(128)
) AS

SELECT c.ClassId, c.Name, c.IsArchived, 
	(SELECT count(*) FROM Roster WHERE ClassId = c.ClassId) as NumberOfStudents
FROM Class c
WHERE c.UserId = @UserId
ORDER BY c.Name, c.ClassId, c.IsArchived