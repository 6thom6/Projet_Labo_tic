CREATE TABLE [dbo].[Proprietaire]
(
	[Id_Proprietaire] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nom_Proprietaire] NVARCHAR(MAX) NULL, 
    [Effectif] INT NULL, 
    [Date_Arrivée] DATETIME NULL, 
    [Dernier_Resultat] NVARCHAR(50) NULL
)
