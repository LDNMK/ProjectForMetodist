CREATE PROCEDURE [dbo].[AddValuesToSpeciality]
AS
BEGIN
	INSERT INTO specialities(speciality_name) 
	VALUES
		('122 - Комп`ютерні науки'),
		('126 - Інформаційні системи та технології'),	
		('121 - Інформаційне програмне забезпечення (магістри)')
END
