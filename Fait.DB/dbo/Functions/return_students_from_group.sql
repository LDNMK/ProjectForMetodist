CREATE FUNCTION return_students_from_group
(
@group_id INT
)
RETURNS TABLE
AS
RETURN
	SELECT id,
	(first_name + ' ' + last_name + ' ' + patronymic) AS full_name 
	FROM students stud
	WHERE EXISTS (
		SELECT 1 
		FROM actual_groups ac_gr
		WHERE ac_gr.student_id = stud.id 
		AND EXISTS (
			SELECT 1 
			FROM Groups gr
			WHERE gr.Id = ac_gr.group_id 
			AND gr.Id = @group_id
			AND gr.Actual = 1
			)
	)