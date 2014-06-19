ALTER PROCEDURE [dbo].[AssignmentInsert] (
	@AssignmentId int output,
	@ClassId int,
	@Name varchar(50),
	@PossiblePoints int,
	@DueDate date,
	@Description varchar(255)
) AS

INSERT INTO Assignment(ClassId, Name, PossiblePoints, DueDate, [Description])
VALUES (@ClassId, @Name, @PossiblePoints,@DueDate,@Description);

SET @AssignmentId = SCOPE_IDENTITY();