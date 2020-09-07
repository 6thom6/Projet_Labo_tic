CREATE TABLE [dbo].[Cheval]
(
	[Id_Cheval] INT NOT NULL PRIMARY KEY,
    [Nom_cheval]NVARCHAR(50) NOT NULL,
    [Pere_cheval] NVARCHAR(50) NOT NULL, 
    [Mere_cheval] NVARCHAR(50) NOT NULL, 
    [Sortie_provisoire] NVARCHAR(50) NULL, 
    [Raison_Sortie] NVARCHAR(50) NULL, 
    [Id_Proprietaire] INT NOT NULL, 
    [Id_Soins] INT NULL,
    [Poids] NVARCHAR(50) NULL, 
    [Race] NVARCHAR(50) NOT NULL, 
    [Alimentation] NVARCHAR(50) NOT NULL, 
    [complement_Alimentation] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Cheval_Proprietaire] FOREIGN KEY ([Id_Proprietaire]) REFERENCES [dbo].[Proprietaire](Id_Proprietaire),
    


)
