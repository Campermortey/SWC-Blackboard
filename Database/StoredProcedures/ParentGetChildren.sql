ALTER PROCEDURE ParentGetChildren
(
	@UserId nvarchar(128)
) AS

SELECT ChildId, u.FirstName, u.LastName
FROM AspNetUsers u
	INNER JOIN Parents 
	ON u.Id = Parents.ChildId
WHERE ParentId = @UserId

