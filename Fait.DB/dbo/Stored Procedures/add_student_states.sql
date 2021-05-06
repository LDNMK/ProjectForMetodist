CREATE   PROCEDURE add_student_states
AS
BEGIN
INSERT INTO student_states(id,student_state_name) VALUES(1,'Перехід з группою'),(2,'Академічна відпустка'),(3,'Перехід в іншу группу'),(4,'Не закрита сессія'),(5,'Студент відрахован'),(6,'Студент отримав ступінь')
END
