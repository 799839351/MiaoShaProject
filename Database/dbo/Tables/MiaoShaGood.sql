CREATE TABLE [dbo].[MiaoShaGood] (
    [Id]           BIGINT       IDENTITY (1, 1) NOT NULL,
    [GoodId]       BIGINT       NULL,
    [MiaoShaPrice] DECIMAL (18) NULL,
    [StockCount]   INT          NULL,
    [StartDate]    DATETIME     NULL,
    [EndDate]      DATETIME     NULL,
    CONSTRAINT [PK_MiaoShaGood] PRIMARY KEY CLUSTERED ([Id] ASC)
);

