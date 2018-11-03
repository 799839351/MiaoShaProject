CREATE TABLE [dbo].[Users] (
    [UserID]     INT            IDENTITY (1, 1) NOT NULL,
    [UserUid]    NVARCHAR (50)  NULL,
    [UserName]   NVARCHAR (50)  NULL,
    [Password]   NVARCHAR (50)  NULL,
    [Sex]        INT            NULL,
    [Email]      NVARCHAR (50)  NULL,
    [State]      INT            NULL,
    [IsDeleted]  BIT            NULL,
    [CreateTime] DATETIME       NULL,
    [Remark]     NVARCHAR (128) NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

