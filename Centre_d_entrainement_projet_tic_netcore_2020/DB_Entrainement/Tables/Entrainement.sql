CREATE TABLE [dbo].[Entrainement]
(
	[Id_Entainement] INT NOT NULL PRIMARY KEY, 
    [Cheval] NVARCHAR(50) NOT NULL, 
    [Plat] NVARCHAR(50) NULL, 
    [Obstacle] NVARCHAR(50) NULL, 
    [Marcheur] NVARCHAR(50) NULL, 
    [Durée] DATETIME NULL, 
    [Pré] NVARCHAR(50) NULL, 


)
