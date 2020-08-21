CREATE TABLE [dbo].[Historique]
(
	[Id_historique] INT NOT NULL PRIMARY KEY, 
    [Id_Cheval] INT NULL, 
    [Debourage] NVARCHAR(50) NULL, 
    [Pré-entrainement] NVARCHAR(50) NULL, 
    [Entraineur_précédent] NVARCHAR(50) NULL, 
    [Proprietaire_précédent] NVARCHAR(50) NULL, 
 
    CONSTRAINT [FK_Historique_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval]), 


)
