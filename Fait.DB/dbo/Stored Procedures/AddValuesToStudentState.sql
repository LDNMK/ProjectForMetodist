
CREATE PROCEDURE AddValuesToStudentState
AS
BEGIN
	INSERT INTO student_states (id, student_state_name) 
	VALUES
		(1, 'Перехід з групою'),
		(2, 'Академічна відпустка'),
		(3, 'Перехід в іншу группу'),
		(4, 'Не закрита сесія'),
		(5, 'Студент відрахований'),
		(6, 'Студент отримав ступінь')
END
