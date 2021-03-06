USE [SWC_LMS]
GO
/****** Object:  StoredProcedure [dbo].[ClassSummaryGetList]    Script Date: 6/9/2014 4:12:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ClassSummaryGetList]
(
	@UserId nvarchar(128)
) AS

SELECT c.ClassId, c.Name, c.IsArchived, 
	(SELECT count(*) FROM Roster WHERE ClassId = c.ClassId) as NumberOfStudents
FROM Class c
WHERE c.UserId = @UserId