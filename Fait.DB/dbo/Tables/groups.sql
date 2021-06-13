CREATE TABLE [dbo].[groups] (
    [id]                INT     IDENTITY (1, 1) NOT NULL,
    [plan_id]           INT     NULL,
    [group_number]      INT     NOT NULL,
    [GroupPrefixId]     INT     NULL,
    [actual]            BIT     NOT NULL,
    [Course]            INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([GroupPrefixId]) REFERENCES [dbo].[GroupPrefix] ([Id]),
    FOREIGN KEY ([plan_id]) REFERENCES [dbo].[year_plans] ([id]) ON DELETE SET NULL
);

