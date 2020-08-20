CREATE TABLE [dbo].[Soins]
(
	[Id_Soins] INT NOT NULL PRIMARY KEY, 
    [Vermifuge] DATE NOT NULL, 
    [Marechal_derniere_visite] DATE NOT NULL, 
    [Alimentation] NVARCHAR(50) NOT NULL, 
    [Complement_Alimentation] NVARCHAR(50) NOT NULL, 
    [Note_Libre] NVARCHAR(MAX) NULL
)
