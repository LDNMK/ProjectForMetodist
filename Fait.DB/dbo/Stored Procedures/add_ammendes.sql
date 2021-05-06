
CREATE PROCEDURE add_ammendes
AS
BEGIN
INSERT INTO ammendes (id,ammend_type) 
VALUES(1,'Інформація відсутня'),(2,'Державний кредит'),(3,'Фізична особа'),(4,'Юридична особа')
END
