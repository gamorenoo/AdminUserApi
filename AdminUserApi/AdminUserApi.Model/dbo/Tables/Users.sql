CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT (newid()), 
    [Code] VARCHAR(100) NOT NULL UNIQUE,
    [Name] VARCHAR(100) NOT NULL, 
    [LastName] VARCHAR(100) NOT NULL, 
    [Address] VARCHAR(500) NOT NULL, 
    [Phone] VARCHAR(50) NOT NULL, 
    [Email] VARCHAR(200) NOT NULL, 
    [Age] INT NOT NULL, 
    [RoleId] UNIQUEIDENTIFIER NOT NULL,
    [Password] VARCHAR(500) NOT NULL, 
    CONSTRAINT [FK_Users_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identificador unico del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = N'Id'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Código unico del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Code'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Name'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Nombre del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'LastName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Dirección del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Address'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Telefono del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Phone'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Correo electrónico del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Email'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Edad del usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'Age'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Indetificador del rol de usuario',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Users',
    @level2type = N'COLUMN',
    @level2name = 'roleId'
GO