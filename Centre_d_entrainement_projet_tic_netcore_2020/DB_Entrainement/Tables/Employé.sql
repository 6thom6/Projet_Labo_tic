CREATE TABLE [dbo].[Employé]
(
	[Id_Employé] INT NOT NULL PRIMARY KEY, 
    [Nom_Employé] NVARCHAR(50) NOT NULL, 
    [Date_Embauche] DATE NULL, 
    [Statuts_Employé] NVARCHAR(50) NOT NULL, 
    [SoinsId_Cheval] INT NULL, 
    [Soinsid_Soins] INT NULL, 
    CONSTRAINT [FK_Employé_ToSoins] FOREIGN KEY ([Soinsid_Soins]) REFERENCES [dbo].[Soins]([Id_Soins]), 
    CONSTRAINT [FK_Employé_ToChevalId] FOREIGN KEY ([SoinsId_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 
    CONSTRAINT [FK_Employé_ToMymEmployé_Entrainement] FOREIGN KEY ([Id_Employé]) REFERENCES [dbo].[mym_Employé_Entrainement]([EmployéID_Employé])



)
