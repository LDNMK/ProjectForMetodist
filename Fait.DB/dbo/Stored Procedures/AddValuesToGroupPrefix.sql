
CREATE PROCEDURE AddValuesToGroupPrefix
AS
BEGIN
	INSERT INTO GroupPrefix ([Name]) 
	VALUES
		('КН'),
		('БІКС'),
		('ІУСТ'),
		('ДТ')
END
