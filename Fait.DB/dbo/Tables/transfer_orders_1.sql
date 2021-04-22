CREATE TABLE [dbo].[transfer_orders] (
    [order_id]   INT           NOT NULL,
    [student_id] INT           NULL,
    [course]     TINYINT       NOT NULL,
    [order_date] DATE          NOT NULL,
    [content]    NVARCHAR (40) NOT NULL,
    PRIMARY KEY CLUSTERED ([order_id] ASC),
    FOREIGN KEY ([student_id]) REFERENCES [dbo].[students] ([id]) ON DELETE SET NULL
);

