CREATE PROCEDURE [dbo].[transfer_student_to_next_group]
	@studentId int 
AS
	select g.group_number 
	from students st
	join actual_groups ag on ag.student_id = st.id
	join groups g on g.id = ag.group_id
	where st.id = @studentId 
			and g.actual = 1
RETURN 0
