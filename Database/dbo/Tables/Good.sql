CREATE TABLE [dbo].[Good] (
    [Id]     BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (500) NULL,
    [Title]  NVARCHAR (500) NULL,
    [Img]    NVARCHAR (500) NULL,
    [Detail] VARCHAR (5000) NULL,
    [Price]  DECIMAL (18)   NULL,
    [Stock]  BIGINT         NULL,
    CONSTRAINT [PK_Good] PRIMARY KEY CLUSTERED ([Id] ASC)
);

