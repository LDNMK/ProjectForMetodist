CREATE TABLE [dbo].[YearPlanGroups]
(
    [YearPlanId] INT NOT NULL, 
    [GroupId] INT NOT NULL,
    PRIMARY KEY ([YearPlanId], [GroupId]),
    FOREIGN KEY ([YearPlanId]) REFERENCES [dbo].[YearPlan] (Id),
    FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] (Id)
)
