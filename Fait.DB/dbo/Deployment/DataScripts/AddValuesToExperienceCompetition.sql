SET IDENTITY_INSERT [ExperienceCompetitions] ON

MERGE INTO [ExperienceCompetitions] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Інформація відсутня'),
			(2, 'Із стажем'),
			(3, 'Без стажу')
	)
	SOURCE (Id, [Name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [ExperienceCompetitions] OFF
GO
