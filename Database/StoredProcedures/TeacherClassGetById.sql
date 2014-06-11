CREATE PROCEDURE TeacherClassGetById(
	 @ClassID int
) AS

SELECT * FROM Class WHERE ClassID = @ClassID