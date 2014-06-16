CREATE PROCEDURE RosterInsert (
	@UserId nvarchar(128),
	@ClassId int
) AS

INSERT INTO Roster(ClassId, UserId, IsDeleted)
VALUES (@ClassId, @UserId, 0);

