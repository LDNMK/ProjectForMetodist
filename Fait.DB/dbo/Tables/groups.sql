CREATE TABLE [dbo].[groups] (
    [id]         INT IDENTITY (1, 1) NOT NULL,
    [plan_id]    INT NULL,
    [group_name] INT NOT NULL,
    [actual]     BIT NOT NULL,
    [group_year] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([plan_id]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET NULL
);

