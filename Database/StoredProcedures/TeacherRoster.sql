USE SWC_LMS
GO

CREATE PROCEDURE TeacherGetClassRoster
(
	@ClassId int
) AS

select  u.FirstName, u.LastName, u.UserName
from [Class] c
        INNER JOIN AspNetUsers u
        on c.userId = u.Id

        INNER JOIN [roster] r
        on u.Id = r.userID
WHERE r.ClassId = @ClassId;