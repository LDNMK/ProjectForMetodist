
CREATE PROCEDURE AddValuesToStudentsGroup
AS
BEGIN
	INSERT INTO GroupStudents (GroupId, StudentId, GroupYear)
	VALUES
		(1, 1, 2020),
		(1, 2, 2021)
END
