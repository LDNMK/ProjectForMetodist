
CREATE PROCEDURE [dbo].[return_student_group_id]
    @student_id INT
AS
    SELECT TOP(1) id FROM groups g
	WHERE EXISTS (
		SELECT 1 FROM actual_groups ag
		WHERE g.id = ag.group_id
			AND ag.student_id = @student_id 
	)
