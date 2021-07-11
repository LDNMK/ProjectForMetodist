CREATE TABLE [dbo].[Groups] (
    [Id]                INT     IDENTITY (1, 1) NOT NULL,
    [GroupNumber]      INT     NOT NULL,
    [GroupPrefixId]     INT     NULL,
    [Actual]            BIT     NOT NULL,
    [Course]            INT     NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GroupPrefixId]) REFERENCES [dbo].[GroupPrefix] ([Id])
);

