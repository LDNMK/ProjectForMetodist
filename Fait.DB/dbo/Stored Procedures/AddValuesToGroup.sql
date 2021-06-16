
CREATE PROCEDURE AddValuesToGroup
AS
BEGIN
	INSERT INTO [groups] (plan_id, group_number, GroupPrefixId, actual, Course) 
	VALUES
		(1, 11, 1, 1, 1),
		(2, 12, 1, 1, 2),
		(3, 13, 2, 1, 1),
		(3, 14, 3, 1, 1),
		(4, 15, 4, 1, 2),
		(1, 16, 4, 1, 1)
END
