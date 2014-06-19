CREATE PROCEDURE StudentGetClassNameByRosterId
(
	@RosterId int
) AS

SELECT Name
FROM Class
	INNER JOIN Roster
	ON Class.ClassId = roster.ClassId
WHERE Roster.RosterId = 25