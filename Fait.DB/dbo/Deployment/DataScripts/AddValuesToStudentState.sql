
SET IDENTITY_INSERT [student_states] ON

MERGE INTO [student_states] AS o
USING (SELECT *
	FROM
	(
		VALUES
			(1, 'Перехід з групою'),
			(2, 'Академічна відпустка'),
			(3, 'Перехід в іншу группу'),
			(4, 'Не закрита сесія'),
			(5, 'Студент відрахований'),
			(6, 'Студент отримав ступінь')
	)
	SOURCE (Id, [student_state_name])) AS n
ON o.Id = n.Id
WHEN NOT MATCHED BY TARGET THEN
	INSERT (Id, [student_state_name])
	VALUES (n.Id, n.[student_state_name]);

SET IDENTITY_INSERT [student_states] OFF
GO
