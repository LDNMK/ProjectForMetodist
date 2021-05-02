CREATE TABLE [dbo].[students_info] (
    [id]              INT           NOT NULL,
    [birthdate]       DATE          NOT NULL,
    [birth_place]     NVARCHAR (30) NOT NULL,
    [immenseness]     NVARCHAR (30) NOT NULL,
    [marital_status]  TINYINT       DEFAULT ((3)) NULL,
    [registartion]    NVARCHAR (30) NOT NULL,
    [exemption]       NVARCHAR (30) NOT NULL,
    [competition]     TINYINT       DEFAULT ((3)) NULL,
    [from_ins]        NVARCHAR (30) NULL,
    [direction]       NVARCHAR (30) NULL,
    [uniq]            NVARCHAR (30) NULL,
    [no_competititon] NVARCHAR (30) NULL,
    [ammends]         TINYINT       DEFAULT ((3)) NULL,
    [employment_number] INT,
	[employment_authority] NVARCHAR(30),
	[employment_given_date] DATE,
	[registr_or_passport_number] NVARCHAR(50),
    FOREIGN KEY ([id]) REFERENCES [dbo].[students] ([id]),
    PRIMARY KEY CLUSTERED ([id] ASC)
);

