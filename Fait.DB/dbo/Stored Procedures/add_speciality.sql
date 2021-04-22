CREATE   PROCEDURE add_speciality
@kode TINYINT,
@direction NVARCHAR(30)
AS
BEGIN
INSERT INTO FAIT3.dbo.specialities VALUES (@kode,@direction)
END