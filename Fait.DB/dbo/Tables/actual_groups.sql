CREATE TABLE [dbo].[actual_groups] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [group_id]   INT NULL,
    [student_id] INT NULL,
    [actual]     BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([group_id]) REFERENCES [dbo].[groups] ([id]) ON DELETE SET DEFAULT,
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[students] ([id]) ON DELETE SET DEFAULT
);

