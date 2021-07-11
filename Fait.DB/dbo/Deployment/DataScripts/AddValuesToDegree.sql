SET IDENTITY_INSERT [Degree] ON

MERGE INTO [Degree] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Бакалавр'),
			(2, 'Магістр')
	)
	SOURCE (Id, [Name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [Degree] OFF
GO
