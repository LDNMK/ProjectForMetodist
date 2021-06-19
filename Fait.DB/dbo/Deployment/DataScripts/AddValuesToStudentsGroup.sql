
CREATE PROCEDURE AddValuesToStudentsGroup
AS
BEGIN
	INSERT INTO actual_groups (group_id, student_id )
	VALUES
		(1, 1),
		(1, 2)
END
