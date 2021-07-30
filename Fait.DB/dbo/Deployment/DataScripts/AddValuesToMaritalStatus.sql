
SET IDENTITY_INSERT [MaritalStatus] ON

MERGE INTO [MaritalStatus] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Інформація відстутня'),
			(2, 'Одруженний'),
			(3, 'Неодруженний')
	)
	SOURCE (Id, [Name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [MaritalStatus] OFF
GO