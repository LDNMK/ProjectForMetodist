CREATE   PROCEDURE add_subject
@plan_id INT,
@sub_name NVARCHAR(30),
@sub_hours INT,
@ects INT,
@monitoring BIT,
@task BIT,
@semester TINYINT
AS
BEGIN
INSERT INTO FAIT3.dbo.subjects(plan_id,sub_name,sub_hours,ects,monitoring,task,semester) VALUES (@plan_id,@sub_name,@sub_hours,@ects,@monitoring,@task,@semester)
END