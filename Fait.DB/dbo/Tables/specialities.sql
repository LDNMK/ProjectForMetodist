CREATE TABLE [dbo].[specialities] (
    [id]        INT           IDENTITY (1, 1) NOT NULL,
    [kode]      TINYINT       NOT NULL,
    [direction] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

