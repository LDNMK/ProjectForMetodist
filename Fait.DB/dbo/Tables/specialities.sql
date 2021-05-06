CREATE TABLE [dbo].[specialities] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [kode]           TINYINT       NOT NULL,
    [speciality]     NVARCHAR (30) NOT NULL,
    [specialization] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

