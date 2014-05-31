USE LMS
GO

CREATE PROCEDURE CourseInsert
(
	@CourseName varchar(40),
	@DepartmentId int,
	@Detail varchar(141),
	@GradeLevel smallint
) AS

INSERT INTO Course (CourseName, DepartmentId, Detail, GradeLevel)
	VALUES (@CourseName, @DepartmentId, @Detail, @GradeLevel)

GO

CREATE PROCEDURE CourseUpdate
(
	@CourseId int,
	@CourseName varchar(40),
	@DepartmentId int,
	@Detail varchar(141),
	@GradeLevel smallint
) AS

UPDATE Course
	SET CourseName = @CourseName,
	DepartmentId = @DepartmentId,
	Detail = @Detail,
	GradeLevel = @GradeLevel
WHERE GradeLevel = @GradeLevel

GO

CREATE PROCEDURE CourseDelete
(
	@CourseId int
)AS

DELETE FROM Course
WHERE CourseId = @CourseId


 