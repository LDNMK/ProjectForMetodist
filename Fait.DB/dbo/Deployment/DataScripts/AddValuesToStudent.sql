
CREATE PROCEDURE AddValuesToStudent
AS
BEGIN
	INSERT INTO Student(FirstName, LastName, Patronymic, StudentStateId) 
	VALUES
		('Анастасія', 'Гуржій', 'Олександрівна', 1),
		('Владислав', 'Сидорчук', 'Геннадійович', 1)
END
