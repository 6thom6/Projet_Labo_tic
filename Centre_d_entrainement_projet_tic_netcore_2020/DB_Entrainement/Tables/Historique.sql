﻿CREATE TABLE [dbo].[Historique]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Debourage] NVARCHAR(50) NULL, 
    [Pré-entrainement] NVARCHAR(50) NULL, 
    [Entraineur_précédent] NVARCHAR(50) NULL, 
    [Proprietaire_précédent] NVARCHAR(50) NULL
)