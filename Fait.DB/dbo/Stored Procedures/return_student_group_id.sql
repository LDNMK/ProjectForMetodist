
CREATE PROCEDURE [dbo].[return_student_group_id]
    @student_id INT
AS
BEGIN
    SELECT TOP(1) Id 
	FROM Groups g
	WHERE EXISTS (
		SELECT 1 
		FROM actual_groups ag
		WHERE g.Id = ag.group_id
			AND ag.student_id = @student_id 
	)
END