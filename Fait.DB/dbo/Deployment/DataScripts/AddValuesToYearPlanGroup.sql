CREATE PROCEDURE AddValuesToYearPlanGroup
AS
BEGIN
	INSERT INTO [YearPlanGroups](GroupId, YearPlanId) 
	VALUES
		(2, 1),
		(1, 2)
END
