CREATE TABLE [dbo].[MiaoShaUser] (
    [Id]            BIGINT         IDENTITY (1, 1) NOT NULL,
    [NickName]      NVARCHAR (100) NULL,
    [Password]      NVARCHAR (100) NULL,
    [Salt]          NVARCHAR (50)  NULL,
    [Head]          NVARCHAR (128) NULL,
    [RegisterDate]  DATETIME       NULL,
    [LastLoginDate] DATETIME       NULL,
    [LoginCount]    BIGINT         NULL,
    [Mobile]        NVARCHAR (50)  NULL,
    CONSTRAINT [PK_MiaoShaUser] PRIMARY KEY CLUSTERED ([Id] ASC)
);

