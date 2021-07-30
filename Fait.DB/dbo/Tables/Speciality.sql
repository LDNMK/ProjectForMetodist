CREATE TABLE [dbo].[Speciality] (
    [Id]                        INT      IDENTITY (1, 1)    NOT NULL,
    [Name]                      NVARCHAR (250)  NOT NULL,
    [IsOnlyForMasterDegree]     BIT     NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

