CREATE PROCEDURE ClassSelectName (
	@ClassId int
) AS

SELECT Name AS CourseName
FROM Class
WHERE ClassId = @ClassId