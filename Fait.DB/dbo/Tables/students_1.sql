CREATE TABLE [dbo].[students] (
    [id]            INT           IDENTITY (1, 1) NOT NULL,
    [speciality_id] INT           NULL,
    [first_name]    NVARCHAR (60) NOT NULL,
    [last_name]     NVARCHAR (60) NOT NULL,
    [patronymic]    NVARCHAR (60) NOT NULL,
    [stud_state]    TINYINT       DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([speciality_id]) REFERENCES [dbo].[specialities] ([id])
);

