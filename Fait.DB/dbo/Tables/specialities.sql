CREATE TABLE [dbo].[specialities] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [kode]           TINYINT       NOT NULL,
    [speciality_name]     NVARCHAR (30) NOT NULL,
    [specialization_name] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

