CREATE TABLE [dbo].[SubjectSemester] (
    [Id]                    INT    IDENTITY (1, 1) NOT NULL,
    [SubjectId]             INT         NOT NULL,
    [ControlTypeId]         TINYINT    DEFAULT ((0)) NOT NULL,
    [IndividualTaskType]    INT         NOT NULL,
    [SemesterId]            TINYINT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([Id]),
    FOREIGN KEY ([ControlTypeId]) REFERENCES [dbo].[ControlType] ([Id]),
    FOREIGN KEY ([SemesterId]) REFERENCES [dbo].[Semester] ([Id])
);

