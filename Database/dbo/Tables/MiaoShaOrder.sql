CREATE TABLE [dbo].[MiaoShaOrder] (
    [Id]      BIGINT IDENTITY (1, 1) NOT NULL,
    [UserId]  BIGINT NULL,
    [OrderId] BIGINT NULL,
    [GoodId]  BIGINT NULL,
    CONSTRAINT [PK_MiaoShaOrder] PRIMARY KEY CLUSTERED ([Id] ASC)
);

