CREATE TABLE [dbo].[Fracture]
(
	[Type_fracture] NVARCHAR(50) NOT NULL , 
    [fracture_indisponibilité] DATE NOT NULL, 
    [Id_Fracture] INT NOT NULL, 
    PRIMARY KEY ([Id_Fracture]), 
    CONSTRAINT [FK_Fracture_ToSoins] FOREIGN KEY ([Id_Fracture]) REFERENCES [dbo].[Soins]([Id_Soins])
)
