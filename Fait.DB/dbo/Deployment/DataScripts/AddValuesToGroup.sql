
CREATE PROCEDURE AddValuesToGroup
AS
BEGIN
	INSERT INTO [Groups] (GroupNumber, GroupPrefixId, Actual, Course) 
	VALUES
		(11, 1, 1, 1),
		(21, 1, 1, 2),
		(13, 2, 1, 1),
		(14, 3, 1, 1),
		(15, 4, 1, 2),
		(16, 4, 1, 1)
END
