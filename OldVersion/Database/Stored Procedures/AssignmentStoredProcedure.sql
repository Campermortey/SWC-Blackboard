USE LMS
GO

CREATE PROCEDURE AssignmentInsert(
	@SectionId int,
	@AssignmentTypeId int,
	@Title varchar(12),
	@Points int,
	@Detail varchar(141),
	@DueDate date
) AS

INSERT INTO Assignment(SectionId, AssignmentTypeId, Title, Points, Detail, DueDate)
VALUES (@SectionId, @AssignmentTypeId, @Title, @Points, @Detail, @DueDate)

GO

CREATE PROCEDURE AssignmentUdate(
	@AssignmentId int,
	@SectionId int,
	@AssignmentTypeId int,
	@Title varchar(12),
	@Points int,
	@Detail varchar(141),
	@DueDate date

) AS

UPDATE Assignment
	SET SectionId = @SectionId,
	AssignmentTypeId = @AssignmentTypeId,
	Title = @Title,
	Points = @Points,
	Detail = @Detail,
	DueDate = @DueDate
WHERE AssignmentId = @AssignmentId

GO

CREATE PROCEDURE AssignmentDelete
(
	@AssignmentId int
) AS

DELETE FROM Assignment
WHERE AssignmentId = @AssignmentId

GO