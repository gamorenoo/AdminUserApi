CREATE TABLE [dbo].[PermissionRole]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    [PermissionId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_PermissionRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]),
    CONSTRAINT [FK_PermissionRole_Permission] FOREIGN KEY ([PermissionId]) REFERENCES [dbo].[Permission] ([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador unico',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PermissionRole',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador del Rol',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PermissionRole',
    @level2type = N'COLUMN',
    @level2name = N'RoleId'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador del Permiso',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PermissionRole',
    @level2type = N'COLUMN',
    @level2name = N'PermissionId'
GO