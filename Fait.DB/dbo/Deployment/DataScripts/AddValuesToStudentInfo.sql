
CREATE PROCEDURE AddValuesToStudentInfo
AS
BEGIN
	INSERT INTO students_info (
       id
      ,birthdate
      ,birth_place
      ,immenseness
      ,marital_status_id
      ,registration
      ,exemption
      ,expirience_competition_id
      ,transfer_from
      ,transfer_direction
      ,competition_conditions
      ,out_of_competition_info
      ,AmendId
      ,employment_number
      ,employment_authority
      ,employment_given_date
      ,registr_or_passport_number) 
	VALUES
		(1, '2021-04-25', N'Київ', N'укр', null, N'Київ', N'ввв', null, N'ввв', N'ввв', N'ввв', N'ввв', 2, 535355, 5535, '2021-04-29', 242424),
		(2, '1995-01-11', N'Львів', N'укр', null, N'Львів', N'ввв', null, N'ввв', N'ввв', N'ввв', N'ввв', 3, 11111, 2222, '1995-01-11', 333333)
END
