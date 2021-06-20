CREATE TABLE [dbo].[marital_statuses] (
    [id]                  TINYINT    IDENTITY(1, 1)   NOT NULL,
    [marital_status_name] NVARCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

