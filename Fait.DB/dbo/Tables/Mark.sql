CREATE TABLE [dbo].[Mark] (
    [Id]          INT     IDENTITY (1, 1) NOT NULL,
    [StudentId]   INT     NOT NULL,
    [SubjectId]   INT     NOT NULL,
    [SubjectMark] INT     NULL,
    [TaskMark]    INT     NULL,
    [ModifiedOn]  DATE    NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id]),
    FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[SubjectSemester] ([Id])
);

