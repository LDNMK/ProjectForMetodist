
SET IDENTITY_INSERT [ControlType] ON

MERGE INTO [ControlType] AS o
USING (SELECT * 
	   FROM
	   (
		VALUES
			(1, 'Залік'),
			(2, 'Екзамен')
		)
		SOURCE (Id, [Name])) AS n
ON n.Id = o.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [ControlType] OFF
GO