CREATE TABLE [dbo].[StudentTransferHistory] (
    [Id]                INT           IDENTITY(1, 1) NOT NULL,
    [StudentId]         INT           NOT NULL,
    [StateId]           INT           NOT NULL,
    [FromCourse]        TINYINT       NOT NULL,
    [ToCourse]          TINYINT       NOT NULL,
    [OperationDate]     DATE          NOT NULL,
    [OrderNumber] NVARCHAR(50) NULL, 
    [OrderDate] DATE NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[students] ([id]),
    FOREIGN KEY ([StateId]) REFERENCES [dbo].[StudentState] ([Id])
);

