CREATE TABLE [dbo].[mym_Employé_Entrainement]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EmployéID_Employé] INT NOT NULL, 
    [EntrainementID_Entrainement] INT NOT NULL, 
    CONSTRAINT [FK_mym_Employé_Entrainement_ToEntrainement] FOREIGN KEY ([EntrainementID_Entrainement]) REFERENCES [dbo].[Entrainement]([Id_Entainement]), 
    CONSTRAINT [FK_mym_Employé_Entrainement_ToEmployé] FOREIGN KEY ([EmployéID_Employé]) REFERENCES [dbo].[Employé]([Id_Employé])
)
