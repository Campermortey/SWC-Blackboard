CREATE PROCEDURE RosterInsert (
	@UserId nvarchar(128),
	@ClassId int,
	@RosterId int output
) AS

INSERT INTO Roster(ClassId, UserId, IsDeleted)
VALUES (@ClassId, @UserId, 0);

SET @RosterId = SCOPE_IDENTITY();