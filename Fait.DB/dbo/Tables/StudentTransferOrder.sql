CREATE TABLE [dbo].[StudentTransferOrder] (
    [Id]                INT           NOT NULL,
    [StudentId]         INT           NULL,
    [FromCourse]        TINYINT       NOT NULL,
    [ToCourse]          TINYINT       NOT NULL,
    [OperationDate]     DATE          NOT NULL,
    [Content]           NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StudentId]) REFERENCES [dbo].[students] ([id]) ON DELETE SET NULL
);

