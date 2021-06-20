CREATE TABLE [dbo].[SubjectSemester] (
    [Id]                    INT        IDENTITY (1, 1) NOT NULL,
    [SubjectId]             INT NOT NULL,
    [ControlType]           TINYINT    DEFAULT ((0)) NOT NULL,
    [IsIndividualTaskExist] BIT        DEFAULT ((0)) NOT NULL,
    [Semester]              TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subject] ([Id])
);

