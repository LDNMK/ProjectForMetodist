CREATE TABLE [dbo].[students] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [speciality_id] INT           NULL,
    [first_name]    NVARCHAR (60) NOT NULL,
    [last_name]     NVARCHAR (60) NOT NULL,
    [patronymic]    NVARCHAR (60) NOT NULL,
    [student_state_id] INT       DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([speciality_id]) REFERENCES [dbo].[Speciality] ([Id]),
    FOREIGN KEY ([student_state_id]) REFERENCES [dbo].[StudentState] ([Id])
);

