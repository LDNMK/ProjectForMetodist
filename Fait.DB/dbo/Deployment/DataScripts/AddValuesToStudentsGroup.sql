
CREATE PROCEDURE AddValuesToStudentsGroup
AS
BEGIN
	INSERT INTO GroupStudents (GroupId, StudentId, GroupYear, IsActive)
	VALUES
		(1, 1, 2020, 1),
		(1, 2, 2021, 1)
END
