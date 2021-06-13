CREATE TABLE [dbo].[subject_info]
(
	[Id]		INT  IDENTITY(1,1)	NOT NULL,
	[PlanId]    INT					NULL,
	[Name]		NVARCHAR (100)		NOT NULL,
	[Hours]		INT					NOT NULL,
	[Ects]		INT					NOT NULL,
	[Faculty]	NVARCHAR (100)		NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	FOREIGN KEY ([PlanId]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET DEFAULT
)
