CREATE TABLE [dbo].[Role]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Code] VARCHAR(50) NOT NULL UNIQUE,
    [Name] VARCHAR(100) NOT NULL,
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador unico del Rol',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código unico del Rol',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Role',
    @level2type = N'COLUMN',
    @level2name = N'Code'
GO