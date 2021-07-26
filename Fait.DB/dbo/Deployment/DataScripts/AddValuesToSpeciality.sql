
SET IDENTITY_INSERT [Speciality] ON

MERGE INTO [Speciality] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, '122 - Комп`ютерні науки', 0),
			(2, '126 - Інформаційні системи та технології', 0),	
			(3, '121 - Інформаційне програмне забезпечення', 1)
	)
	SOURCE (Id, [Name], IsOnlyForMasterDegree)) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [Name], IsOnlyForMasterDegree)
	VALUES (n.Id, n.[Name], n.IsOnlyForMasterDegree);

SET IDENTITY_INSERT [Speciality] OFF
GO
