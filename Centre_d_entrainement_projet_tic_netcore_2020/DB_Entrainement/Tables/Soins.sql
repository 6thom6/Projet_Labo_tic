CREATE TABLE [dbo].[Soins]
(
	[Id_Soins] INT NOT NULL PRIMARY KEY, 
    [Id_Cheval] INT NOT NULL, 
    [Id_Employe] INT NOT NULL, 
    [Vermifuge] DATE NOT NULL, 
    [Marechal_derniere_visite] DATE NOT NULL, 
    [Note_Libre] NVARCHAR(MAX) NULL, 
    [Type_de_soin] NVARCHAR(50) NULL, 
    [durrée_indisponibilité] NVARCHAR(50) NULL, 
    [date_de_soin] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES[dbo].[Employé]([Id_Employé]),







)
