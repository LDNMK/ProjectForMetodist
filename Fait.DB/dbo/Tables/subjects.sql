CREATE TABLE [dbo].[subjects] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [subject_info_id] INT NOT NULL,
    [monitoring] TINYINT           DEFAULT ((0)) NOT NULL,
    [task]       TINYINT          DEFAULT ((0)) NOT NULL,
    [semester]   TINYINT      NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([subject_info_id]) REFERENCES [dbo].[subject_info] ([id])
);

