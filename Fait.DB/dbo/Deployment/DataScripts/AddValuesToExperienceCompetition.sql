
CREATE PROCEDURE AddValuesToExperienceCompetition
AS
BEGIN
	INSERT INTO ExperienceCompetitions(Id, [Name]) 
	VALUES
		(1, 'Інформація відсутня'),
		(2, 'Із стажем'),
		(3, 'Без стажу')
END
