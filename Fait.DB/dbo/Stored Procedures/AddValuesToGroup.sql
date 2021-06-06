
CREATE PROCEDURE AddValuesToGroup
AS
BEGIN
	INSERT INTO [groups] (plan_id, group_number, GroupPrefixId, actual, group_year, Course) 
	VALUES
		(null, 11, 1, 1, 2021, 1),
		(null, 12, 1, 1, 2020, 2),
		(null, 13, 2, 1, 2021, 1),
		(null, 14, 3, 1, 2021, 1),
		(null, 15, 4, 1, 2020, 2),
		(null, 16, 4, 1, 2021, 1)
END
