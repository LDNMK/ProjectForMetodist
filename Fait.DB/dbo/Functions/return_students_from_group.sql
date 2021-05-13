CREATE   FUNCTION return_students_from_group
(
@group_number INT,
@group_name_id TINYINT
)
RETURNS TABLE
AS
RETURN
SELECT id,(first_name+' '+last_name+' '+patronymic) full_name FROM students stud
WHERE EXISTS(
SELECT 1 FROM actual_groups ac_gr
WHERE ac_gr.student_id=stud.id AND EXISTS(
SELECT 1 FROM groups gr
WHERE gr.id=ac_gr.group_id AND gr.group_number=@group_number AND gr.group_name_id=@group_name_id
)
)