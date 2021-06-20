
SET IDENTITY_INSERT [specialities] ON

MERGE INTO [specialities] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, '122 - Комп`ютерні науки'),
			(2, '126 - Інформаційні системи та технології'),	
			(3, '121 - Інформаційне програмне забезпечення (магістри)')
	)
	SOURCE (Id, [speciality_name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [speciality_name])
	VALUES (n.Id, n.[speciality_name]);

SET IDENTITY_INSERT [specialities] OFF
GO
