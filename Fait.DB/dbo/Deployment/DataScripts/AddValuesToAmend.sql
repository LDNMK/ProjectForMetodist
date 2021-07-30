
SET IDENTITY_INSERT [Amends] ON

MERGE INTO [Amends] AS o
USING (SELECT * 
	   FROM
	   (
		VALUES
			(1, 'Інформація відсутня'),
			(2, 'Державний кредит'),
			(3, 'Фізична особа'),
			(4, 'Юридична особа')
		)
		SOURCE (Id, [Name])) AS n
ON n.Id = o.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name])
	VALUES (n.Id, n.[Name]);

SET IDENTITY_INSERT [Amends] OFF
GO