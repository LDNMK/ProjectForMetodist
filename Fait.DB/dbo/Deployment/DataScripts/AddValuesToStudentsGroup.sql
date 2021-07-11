
CREATE PROCEDURE AddValuesToStudentsGroup
AS
BEGIN
	INSERT INTO ActualGroups (GroupId, StudentId )
	VALUES
		(1, 1),
		(1, 2)
END
