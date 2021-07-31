CREATE TABLE [dbo].[StudentTransferHistory] (
    [Id]                INT           IDENTITY(1, 1) NOT NULL,
    [StudentId]         INT           NOT NULL,
    [StateId]           INT           NOT NULL,
    [FromCourse]        TINYINT       NOT NULL,
    [ToCourse]          TINYINT       NOT NULL,
    [OperationDate]     DATE          NOT NULL,
    [OrderNumber]       NVARCHAR(50) NULL, 
    [OrderDate]         DATE NULL, 
    [Content] NVARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Student] ([Id]),
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[StudentState] ([Id])
);

