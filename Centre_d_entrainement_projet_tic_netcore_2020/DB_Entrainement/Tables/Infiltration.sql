CREATE TABLE [dbo].[Infiltration]
(
	[Id_Infiltration] INT NOT NULL PRIMARY KEY, 
    [Infiltration_Type] NVARCHAR(50) NULL, 
    [Delai_infiltration_indisponibilité] DATE NULL, 
    CONSTRAINT [FK_Infiltration_ToSoins] FOREIGN KEY ([Id_Infiltration]) REFERENCES [dbo].[Soins]([Id_Soins])
)
