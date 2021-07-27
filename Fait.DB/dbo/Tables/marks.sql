﻿CREATE TABLE [dbo].[marks] (
    [id]           INT     IDENTITY (1, 1) NOT NULL,
    [student_id]   INT     NOT NULL,
    [subject_id]   INT     NOT NULL,
    [subject_mark] TINYINT NULL,
    [task_mark]    TINYINT NULL,
    [ModifiedOn] DATE NULL, 
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[students] ([id]),
    FOREIGN KEY ([subject_id]) REFERENCES [dbo].[SubjectSemester] ([Id])
);

