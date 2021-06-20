CREATE TABLE [dbo].[YearPlan] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (40) NOT NULL,
    [Year] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

