CREATE TABLE [dbo].[GroupStudents] (
    [GroupId]   INT NOT NULL,
    [StudentId] INT NOT NULL,
    [GroupYear] INT NOT NULL, 
    [IsActive]  BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([GroupId], [StudentId] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id])
);

