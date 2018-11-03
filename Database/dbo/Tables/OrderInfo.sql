CREATE TABLE [dbo].[OrderInfo] (
    [Id]             BIGINT         IDENTITY (1, 1) NOT NULL,
    [UserId]         BIGINT         NULL,
    [GoodId]         BIGINT         NULL,
    [DeliveryAddrId] BIGINT         NULL,
    [GoodName]       NVARCHAR (500) NULL,
    [GoodCount]      INT            NULL,
    [GoodPrice]      DECIMAL (18)   NULL,
    [OrderChannel]   INT            NULL,
    [Status]         INT            NULL,
    [CreateTime]     DATETIME       NULL,
    [PayTime]        DATETIME       NULL,
    CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

