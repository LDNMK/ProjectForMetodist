
CREATE PROCEDURE [dbo].[return_student_group_id]
    @student_id INT
AS
BEGIN
    SELECT TOP(1) Id 
	FROM Groups g
	WHERE EXISTS (
		SELECT 1 
		FROM ActualGroups ag
		WHERE g.Id = ag.GroupId
			AND ag.StudentId = @student_id 
	)
END