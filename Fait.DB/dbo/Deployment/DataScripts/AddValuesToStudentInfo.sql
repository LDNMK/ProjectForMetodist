
CREATE PROCEDURE AddValuesToStudentInfo
AS
BEGIN
    SET IDENTITY_INSERT [students_info] ON

    INSERT INTO students_info (
       id
      ,birthdate
      ,birth_place
      ,DegreeId
      ,Citizenship
      ,GraduatedSchoolName
      ,GraduatedYear
      ,marital_status_id
      ,registration
      ,exemption
      ,expirience_competition_id
      ,transfer_from
      ,transfer_direction
      ,competition_conditions
      ,out_of_competition_info
      ,AmendId
      ,OrderDate
      ,OrderNumber
      ,employment_number
      ,employment_authority
      ,employment_given_date
      ,registr_or_passport_number) 
	VALUES
		(1, '2021-04-25', N'Київ', 1, N'укр', N'School 1', 2050, 1, N'Київ', N'ввв', 1, N'ввв', N'ввв', N'ввв', N'ввв', 2, '2021-05-03', 111, 535355, 5535, '2021-04-29', 242424),
		(2, '1995-01-11', N'Львів', 2 , N'укр', N'School 2', 2100, 2, N'Львів', N'ввв', 2, N'ввв', N'ввв', N'ввв', N'ввв', 3, '2021-09-11',222,  11111, 2222, '1995-01-11', 333333)
    
    SET IDENTITY_INSERT [students_info] OFF
END
