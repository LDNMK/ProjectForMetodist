CREATE TABLE [dbo].[subject_info]
(
	[Id] INT  IDENTITY NOT NULL PRIMARY KEY,
	 [plan_id]    INT           NULL,
	[sub_name]   NVARCHAR (100) NOT NULL,
	sub_hours INT NOT NULL,
	ects INT NOT NULL,
	faculty nvarchar(100)
   FOREIGN KEY ([plan_id]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET DEFAULT
)
