﻿CREATE TABLE [dbo].[students_info] (
    [id]                         INT     IDENTITY(1,1)    NOT NULL,
    [birthdate]                  DATE          NOT NULL,
    [birth_place]                NVARCHAR (50) NOT NULL,
    [DegreeId]                   INT           NOT NULL,
    [Citizenship]                NVARCHAR (30) NOT NULL,
    [GraduatedSchoolName]        NVARCHAR (200)NULL,
    [GraduatedYear]              INT           NULL,
    [marital_status_id]          TINYINT       DEFAULT ((1)) NULL,
    [registration]               NVARCHAR (30) NOT NULL,
    [exemption]                  NVARCHAR (30) NOT NULL,
    [expirience_competition_id]  TINYINT       DEFAULT ((1)) NULL,
    [transfer_from]              NVARCHAR (200)NULL,
    [transfer_direction]         NVARCHAR (200)NULL,
    [competition_conditions]     NVARCHAR (30) NULL,
    [out_of_competition_info]    NVARCHAR (30) NULL,
    [AmendId]                    INT            DEFAULT ((1)) NULL,
    [employment_number]          INT           NULL,
    [employment_authority]       NVARCHAR (30) NULL,
    [employment_given_date]      DATE          NULL,
    [OrderNumber]                INT           NULL,
    [OrderDate]                  DATE      NULL,
    [registr_or_passport_number] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    FOREIGN KEY ([AmendId]) REFERENCES [dbo].[Amend] ([Id]),
    FOREIGN KEY ([expirience_competition_id]) REFERENCES [dbo].[ExperienceCompetitions] ([Id]),
    FOREIGN KEY ([marital_status_id]) REFERENCES [dbo].[marital_statuses] ([id]),
    FOREIGN KEY ([DegreeId]) REFERENCES [dbo].[Degree] (Id),
    UNIQUE ([registr_or_passport_number])
);

