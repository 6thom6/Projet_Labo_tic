CREATE TABLE [dbo].[Soins]
(
	[Id_Soins] INT NOT NULL PRIMARY KEY, 
    [Id_Cheval] INT NOT NULL, 
    [Id_Employe] INT NOT NULL, 
    [Vermifuge] DATE NOT NULL, 
    [Marechal_derniere_visite] DATE NOT NULL, 
    [Alimentation] NVARCHAR(50) NOT NULL, 
    [Complement_Alimentation] NVARCHAR(50) NOT NULL, 
    [Note_Libre] NVARCHAR(MAX) NULL, 
  
    CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES[dbo].[Employé]([Id_Employé]),



)
