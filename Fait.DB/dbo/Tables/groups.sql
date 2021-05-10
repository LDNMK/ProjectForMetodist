CREATE TABLE [dbo].[groups] (
    [id]            INT     IDENTITY (1, 1) NOT NULL,
    [plan_id]       INT     NULL,
    [group_number]  INT     NOT NULL,
    [group_name_id] TINYINT NULL,
    [actual]        BIT     NOT NULL,
    [group_year]    INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([group_name_id]) REFERENCES [dbo].[group_names] ([id]),
    FOREIGN KEY ([plan_id]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET NULL
);

