﻿
CREATE PROCEDURE add_mariatal_statuses
AS
BEGIN
INSERT INTO marital_statuses(id,marital_status_name) 
VALUES(1,'Інформація відстутня'),(2,'Одружений/Заміжня'),(3,'Неодружений/Незаміжня')
END
