CREATE TABLE [dbo].[subjects] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [plan_id]    INT           NULL,
    [sub_name]   NVARCHAR (30) NOT NULL,
    [sub_hours]  INT           NOT NULL,
    [ects]       INT           NOT NULL,
    [monitoring] BIT           DEFAULT ((0)) NOT NULL,
    [task]       BIT           DEFAULT ((0)) NOT NULL,
    [semester]   TINYINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([plan_id]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET DEFAULT
);

