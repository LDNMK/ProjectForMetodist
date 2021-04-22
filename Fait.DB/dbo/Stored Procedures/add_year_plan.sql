
CREATE   PROCEDURE add_year_plan
@plan_name NVARCHAR(40),
@plan_year INT,
@course TINYINT
AS
BEGIN
INSERT INTO FAIT3.dbo.year_plans(plan_name,plan_year,course) VALUES (@plan_name,@plan_year,@course)
END