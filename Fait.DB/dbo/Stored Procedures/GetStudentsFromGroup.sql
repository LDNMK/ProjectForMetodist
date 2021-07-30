CREATE PROCEDURE [dbo].[GetStudentsFromGroup]
	@GroupId INT,
	@Year	 INT = NULL
AS

		RETURN 
		SELECT
			s.Id as StudentId,
			(FirstName + ' ' + LastName + ' ' + Patronymic) AS StudentName 
		FROM Student s
		JOIN GroupStudents gs ON gs.StudentId = s.Id AND gs.GroupId = @GroupId

	--RETURN 
	--SELECT
	--	s.Id as StudentId,
	--	(first_name + ' ' + last_name + ' ' + patronymic) AS StudentName 
	--FROM Students s
	--JOIN GroupStudents gs ON gs.StudentId = s.Id AND gs.GroupId = @GroupId AND gs.GroupYear = @Year

	--IF (@Year IS NULL)
	--BEGIN
	--	RETURN 
	--	SELECT
	--		s.Id as StudentId,
	--		(first_name + ' ' + last_name + ' ' + patronymic) AS StudentName 
	--	FROM Students s
	--	JOIN GroupStudents gs ON gs.StudentId = s.Id AND gs.GroupId = @GroupId
	--END



