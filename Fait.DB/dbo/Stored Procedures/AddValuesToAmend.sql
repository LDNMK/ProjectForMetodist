
CREATE PROCEDURE AddValuesToAmend
AS
BEGIN
	INSERT INTO Amend (Name) 
	VALUES
		('Інформація відсутня'),
		('Державний кредит'),
		('Фізична особа'),
		('Юридична особа')
END
