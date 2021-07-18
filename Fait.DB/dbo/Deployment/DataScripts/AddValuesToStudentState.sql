
SET IDENTITY_INSERT [StudentState] ON

MERGE INTO [StudentState] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Перехід з курсу на курс'),
			(2, 'Перерва в академічному навчанні'),
			(3, 'Студент відрахований'),
			(4, 'Студент отримав ступінь')
	)
	SOURCE (Id, [Name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [StudentState] OFF
GO
