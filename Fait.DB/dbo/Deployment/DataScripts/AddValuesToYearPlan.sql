
CREATE PROCEDURE AddValuesToYearPlan
AS
BEGIN
	INSERT INTO YearPlan([Name], [Year]) 
	VALUES
		('test 1', 2020),
		('test 2', 2020),
		('test 3', 2021),
		('test 4', 2021)
END
