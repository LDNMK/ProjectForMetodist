CREATE TABLE [dbo].[marks] (
    [id]           INT     IDENTITY (1, 1) NOT NULL,
    [student_id]   INT     NULL,
    [subject_id]   INT     NULL,
    [subject_mark] TINYINT NOT NULL,
    [task_mark]    TINYINT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[students] ([id]) ON DELETE SET DEFAULT,
    FOREIGN KEY ([subject_id]) REFERENCES [dbo].[SubjectSemester] ([Id]) ON DELETE SET DEFAULT
);

