CREATE TABLE [dbo].[ActualGroups] (
    [GroupId]   INT NOT NULL,
    [StudentId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([GroupId], [StudentId] ASC),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([Id]),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[students] ([id])
);

