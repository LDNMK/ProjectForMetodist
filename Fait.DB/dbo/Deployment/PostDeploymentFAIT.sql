/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r .\DataScripts\AddValuesToAmend.sql
:r .\DataScripts\AddValuesToExperienceCompetition.sql
:r .\DataScripts\AddValuesToMaritalStatus.sql
:r .\DataScripts\AddValuesToSpeciality.sql
:r .\DataScripts\AddValuesToStudentState.sql
:r .\DataScripts\AddValuesToDegree.sql
:r .\DataScripts\AddValuesToSemester.sql
:r .\DataScripts\AddValuesToControlType.sql
