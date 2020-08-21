CREATE TABLE [dbo].[mym_Cheval_Entrainement]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MYM_ChevaliId_Cheval] INT NULL, 
    [MYM_Entrainementid_Entrainement] INT NULL, 
    CONSTRAINT [FK_mym_Cheval_Entrainement_ToEntrainement] FOREIGN KEY ([MYM_ChevaliId_Cheval]) REFERENCES [dbo].[Entrainement]([Id_Entainement]), 
    CONSTRAINT [FK_mym_Cheval_Entrainement_ToCheval] FOREIGN KEY ([MYM_Entrainementid_Entrainement]) REFERENCES [dbo].[Entrainement]([Id_Entainement])



)
