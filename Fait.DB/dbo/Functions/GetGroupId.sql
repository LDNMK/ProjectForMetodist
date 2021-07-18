CREATE FUNCTION [dbo].[GetGroupId]
(
	@Course INT,
	@GroupPrefixId INT
)
RETURNS INT
AS
BEGIN
	RETURN (
		SELECT g.Id
		FROM Groups g
		WHERE 
			g.Actual = 1
			AND g.Course = @Course
			AND g.GroupPrefixId = @GroupPrefixId
	)
END
