
SET IDENTITY_INSERT [Semester] ON

MERGE INTO [Semester] AS o
USING (SELECT * 
	   FROM
	   (
		VALUES
			(1, 'Осінь'),
			(2, 'Весна')
		)
		SOURCE (Id, [Name])) AS n
ON n.Id = o.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [Semester] OFF
GO