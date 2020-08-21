CREATE TABLE [dbo].[Vaccination]
(
	[Id_vaccination] INT NOT NULL PRIMARY KEY, 
    [Nom_vaccin] NVARCHAR(50) NOT NULL, 
    [Delai_Indisponibilité] DATE NOT NULL
)
