
CREATE   PROCEDURE add_years_plans
@plan_name nvarchar(40),
@plan_year int,
@course tinyint
AS
BEGIN
INSERT INTO FAIT3.dbo.year_plans(plan_name,plan_year,course) VALUES (@plan_name,@plan_year,@course)
END
