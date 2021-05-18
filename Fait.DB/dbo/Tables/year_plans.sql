CREATE TABLE [dbo].[year_plans] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [plan_name] NVARCHAR (40) NOT NULL,
    [plan_year] INT           NOT NULL,
    [course]   TINYINT       NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

