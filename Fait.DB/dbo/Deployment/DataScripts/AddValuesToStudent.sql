
CREATE PROCEDURE AddValuesToStudent
AS
BEGIN
	INSERT INTO students (first_name, last_name, patronymic, student_state_id) 
	VALUES
		('Анастасія', 'Гуржій', 'Олександрівна', 1),
		('Владислав', 'Сидорчук', 'Геннадійович', 4)
END
