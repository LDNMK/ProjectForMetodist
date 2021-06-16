
CREATE PROCEDURE AddValuesToYearPlan
AS
BEGIN
	INSERT INTO year_plans (plan_name, plan_year, course) 
	VALUES
		('test 1', 2020, 1),
		('test 2', 2020, 2),
		('test 3', 2021, 1),
		('test 4', 2021, 2)
END
