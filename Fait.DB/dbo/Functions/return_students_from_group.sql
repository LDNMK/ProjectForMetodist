CREATE FUNCTION return_students_from_group
(
	@group_id INT,
	@year int
)
RETURNS TABLE
AS
RETURN
	SELECT id,
	(first_name + ' ' + last_name + ' ' + patronymic) AS full_name 
	FROM students stud
	WHERE EXISTS (
		SELECT 1 
		FROM GroupStudents ac_gr
		WHERE ac_gr.StudentId = stud.id 
		AND ac_gr.GroupYear = @year
		AND EXISTS (
			SELECT 1 
			FROM Groups gr
			WHERE gr.Id = ac_gr.GroupId 
			AND gr.Id = @group_id
			AND gr.Actual = 1
			)
	)