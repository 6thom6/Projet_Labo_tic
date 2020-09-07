/*
Script de déploiement pour DB_Entrainement

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_Entrainement"
:setvar DefaultFilePrefix "DB_Entrainement"
:setvar DefaultDataPath "C:\Users\thomas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\"
:setvar DefaultLogPath "C:\Users\thomas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\mssqllocaldb\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Suppression de [dbo].[FK_Cheval_Soins]...';


GO
ALTER TABLE [dbo].[Cheval] DROP CONSTRAINT [FK_Cheval_Soins];


GO
PRINT N'Modification de [dbo].[Cheval]...';


GO
ALTER TABLE [dbo].[Cheval] ALTER COLUMN [Id_Soins] INT NULL;


GO
PRINT N'Création de [dbo].[FK_Cheval_Soins]...';


GO
ALTER TABLE [dbo].[Cheval] WITH NOCHECK
    ADD CONSTRAINT [FK_Cheval_Soins] FOREIGN KEY ([Id_Soins]) REFERENCES [dbo].[Soins] ([Id_Soins]);


GO
/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

SET IDENTITY_INSERT [Proprietaire] ON
insert [dbo].[Proprietaire]([dbo].[Proprietaire].[Id_Proprietaire],[dbo].[Proprietaire].[Nom_Proprietaire],[dbo].[Proprietaire].[Effectif],[dbo].[Proprietaire].[Date_Arrivée],[dbo].[Proprietaire].[Dernier_Resultat])
values
('1','nicole','35','2020-12-05','1er'),
('2','papot','20','2020-06-03','1er'),
('3','schule','10','2020-08-04','2eme'),
('4','Delay','5','2020-07-05','np'),
('5','deWaele','1','2020-10-15','np')

INSERT INTO [dbo].[Cheval] ([dbo].[Cheval].[Id_Cheval],[dbo].[Cheval].[Nom_cheval],[dbo].[Cheval].[Pere_cheval],[dbo].[Cheval].[Mere_cheval],
[dbo].[Cheval].[Sortie_provisoire],[dbo].[Cheval].[Raison_Sortie],[dbo].[Cheval].[Id_Proprietaire],[dbo].[Cheval].[Id_Soins],[dbo].[Cheval].[Poids],[dbo].[Cheval].[Race])
VALUES  
('1','dala','dalakhani','zarkava','2020-07-02','repos','1','1','450','PS'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','1','2','450','PS'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','3','3','450','PS'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','1','4','450','PS'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','1','5','450','PS');

insert into [dbo].[Couse] ([dbo].[Couse].[Id_Courses], [dbo].[Couse].[Hippodrome], [dbo].[Couse].[Date_Courses],[dbo].[Couse].[Distance],[dbo].[Couse].[Corde],[dbo].[Couse].[Discipline],
                    [dbo].[Couse].[Terrain],[dbo].[Couse].[Avis],[dbo].[Couse].[Jockey],[dbo].[Couse].[Poids_De_Course])
Values 
('1','Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('2','Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('3','Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('4','Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('5','Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')

insert into [dbo].[Fracture]([dbo].[Fracture].[Id_Fracture], [dbo].[Fracture].[Type_fracture], [dbo].[Fracture].[fracture_indisponibilité])
values
('1','boulet','6mois'),
('2','canon','1an'),
('3','jarret','3mois'),
('4','boulet','6mois');

insert [dbo].[Historique] ([dbo].[Historique].[Id_historique],[dbo].[Historique].[Id_Cheval],[dbo].[Historique].[Debourage],[dbo].[Historique].[Pré-entrainement],[dbo].[Historique].[Entraineur_précédent],[dbo].[Historique].[Proprietaire_précédent])
values
('1','2','malenfant','malenfant','dubois','dubuisson'),
('2','4','perceval','perceval','nami','dubuisson'),
('3','3','caradoc','perceval','dubois','leona'),
('4','5','dugarry','marion','leblanc','dubuisson'),
('5','2','malenfant','malenfant','dubois','kartus');

insert [dbo].[Infiltration] ([dbo].[Infiltration].[Id_Infiltration],[dbo].[Infiltration].[Infiltration_Type],[dbo].[Infiltration].[Delai_infiltration_indisponibilité])
values
('1','anterieur_droit','1semaine'),
('2','posterieur_droit','1semaine'),
('3','anterieur_gauche','1semaine'),
('4','genoux_droit','1semaine'),
('5','genoux_gauche','1semaine')



insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],[dbo].[Soins].[Id_Soins],[dbo].[Soins].[Id_Employe],[dbo].[Soins].[Vermifuge],[dbo].[Soins].[Marechal_derniere_visite],[dbo].[Soins].[Alimentation],[dbo].[Soins].[Complement_Alimentation],[dbo].[Soins].[Note_Libre])
values
('1','1','4','2020-01-25','2020-09-10','complet','none','attention_a_l_eau'),
('1','2','2','2020-04-07','2020-08-11','2litres','poudre','none'),
('2','3','2','2020-03-25','2020-07-15','1litre','none','none'),
('4','4','4','2020-01-15','2020-06-04','complet','sucre_a_paille','attention_a_l_eau'),
('3','5','4','2020-06-25','2020-09-10','complet','none','attention_a_l_eau')

insert [dbo].[Tendinite] ([dbo].[Tendinite].[Id_Tendinite],[dbo].[Tendinite].[Type_tendinite],[dbo].[Tendinite].[tendinite_Indisponibilité])
values
('1','anterieur_droit','6'),
('2','anterieur_droit_et_gauche','6'),
('3','posertieur_droit','6'),
('4','posertieur_gauche','6'),
('5','anterieur_gauche','6')

insert [dbo].[Vaccination]([dbo].[Vaccination].[Id_vaccination],[dbo].[Vaccination].[Nom_vaccin],[dbo].[Vaccination].[Delai_Indisponibilité])
values
('1','polyo','2020-10-10'),
('5','polyo','2020-10-12'),
('3','polyo','2020-10-13'),
('4','polyo','2020-10-14'),
('2','polyo','2020-10-15')

insert into [dbo].[Entrainement] ([dbo].[Entrainement].[Id_Entainement],[dbo].[Entrainement].[Cheval],[dbo].[Entrainement].[Plat],[dbo].[Entrainement].[Obstacle],[dbo].[Entrainement].[Marcheur],[dbo].[Entrainement].[Durée],[dbo].[Entrainement].[Pré])
values 
('1','dala','1000m','2tours','none','2h','none'),
('2','khani','1500m','3tours','none','2h','none'),
('3','zarkandar','2000m','6tours','none','2h30','none'),
('4','dubawi','3500m','2tours','none','2h','none'),
('5','alpha spirit','3000m','none','2h','1h','none')


insert into [dbo].[Employé] ([dbo].[Employé].[Id_Employé], [dbo].[Employé].[Nom_Employé], [dbo].[Employé].[Date_Embauche], [dbo].[Employé].[Statuts_Employé])
values
('1','zuliani','2020-10-01','jockey'),
('2','Lemagnen','2020-10-02','apprenti'),
('3','Nabet','2020-10-03','garcon_decurie'),
('4','Lestrade','2020-10-04','garcon_de_voyage'),
('5','Gallon','2020-10-05','jockey')


GO

GO
PRINT N'Vérification de données existantes par rapport aux nouvelles contraintes';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Cheval] WITH CHECK CHECK CONSTRAINT [FK_Cheval_Soins];


GO
PRINT N'Mise à jour terminée.';


GO
