CREATE TABLE [dbo].[Student] (
    [Id]             INT    IDENTITY (1, 1) NOT NULL,
    [SpecialityId]   INT           NULL,
    [FirstName]      NVARCHAR (60) NOT NULL,
    [LastName]       NVARCHAR (60) NOT NULL,
    [Patronymic]     NVARCHAR (60) NOT NULL,
    [StudentStateId] INT       DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([SpecialityId]) REFERENCES [dbo].[Speciality] ([Id]),
    FOREIGN KEY ([StudentStateId]) REFERENCES [dbo].[StudentState] ([Id])
);

