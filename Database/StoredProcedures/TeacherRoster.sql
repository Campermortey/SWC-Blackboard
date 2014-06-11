USE SWC_LMS
GO

ALTER PROCEDURE TeacherGetClassRoster
(
	@ClassId int
) AS

select  u.FirstName, u.LastName, u.UserName, r.ClassId, r.UserId
from AspNetUsers u
        INNER JOIN [roster] r
        on u.Id = r.userID
WHERE r.ClassId = @ClassId AND r.IsDeleted=0;