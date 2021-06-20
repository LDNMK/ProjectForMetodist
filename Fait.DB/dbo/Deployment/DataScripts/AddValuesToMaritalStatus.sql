
SET IDENTITY_INSERT [marital_statuses] ON

MERGE INTO [marital_statuses] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Інформація відстутня'),
			(2, 'Одруженний'),
			(3, 'Неодруженний')
	)
	SOURCE (Id, [marital_status_name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [marital_status_name])
	VALUES (n.Id, n.[marital_status_name]);

SET IDENTITY_INSERT [marital_statuses] OFF
GO