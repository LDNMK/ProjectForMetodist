CREATE TABLE [dbo].[subjects] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [subject_info_id] INT NOT NULL,
    [monitoring] BIT           DEFAULT ((0)) NOT NULL,
    [task]       BIT           DEFAULT ((0)) NOT NULL,
    [semester]   BIT       NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([subject_info_id]) REFERENCES [dbo].[subject_info] ([id])
);

