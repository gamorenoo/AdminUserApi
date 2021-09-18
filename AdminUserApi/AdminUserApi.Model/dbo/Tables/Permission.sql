CREATE TABLE [dbo].[Permission]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Code] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(100) NOT NULL,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador unico del Permiso',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código unico del Permiso',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del Permiso',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Permission',
    @level2type = N'COLUMN',
    @level2name = N'Name'
GO