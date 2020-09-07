/*
Script de déploiement pour 26

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "26"
:setvar DefaultFilePrefix "26"
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
PRINT N'Suppression de [dbo].[FK_Tendinite_ToSoins]...';


GO
ALTER TABLE [dbo].[Tendinite] DROP CONSTRAINT [FK_Tendinite_ToSoins];


GO
PRINT N'Création de [dbo].[FK_Soins_ToFracture]...';


GO
ALTER TABLE [dbo].[Soins] WITH NOCHECK
    ADD CONSTRAINT [FK_Soins_ToFracture] FOREIGN KEY ([Id_Soins]) REFERENCES [dbo].[Fracture] ([Id_Fracture]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToInfiltration]...';


GO
ALTER TABLE [dbo].[Soins] WITH NOCHECK
    ADD CONSTRAINT [FK_Soins_ToInfiltration] FOREIGN KEY ([Id_Soins]) REFERENCES [dbo].[Infiltration] ([Id_Infiltration]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToTendinite]...';


GO
ALTER TABLE [dbo].[Soins] WITH NOCHECK
    ADD CONSTRAINT [FK_Soins_ToTendinite] FOREIGN KEY ([Id_Soins]) REFERENCES [dbo].[Tendinite] ([Id_Tendinite]);


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

insert [dbo].[Tendinite] ([dbo].[Tendinite].[Id_Tendinite],[dbo].[Tendinite].[Type_tendinite],[dbo].[Tendinite].[tendinite_Indisponibilité])
values
('11','anterieur_droit','6'),
('12','anterieur_droit_et_gauche','6'),
('13','posertieur_droit','6'),
('14','posertieur_gauche','6'),
('15','anterieur_gauche','6')

insert [dbo].[Vaccination]([dbo].[Vaccination].[Id_vaccination],[dbo].[Vaccination].[Nom_vaccin],[dbo].[Vaccination].[Delai_Indisponibilité])
values
('1','polyo','2020-10-10'),
('5','polyo','2020-10-12'),
('3','polyo','2020-10-13'),
('4','polyo','2020-10-14'),
('2','polyo','2020-10-15')

insert [dbo].[Infiltration] ([dbo].[Infiltration].[Id_Infiltration],[dbo].[Infiltration].[Infiltration_Type],[dbo].[Infiltration].[Delai_infiltration_indisponibilité])
values
('1','anterieur_droit','1semaine'),
('2','posterieur_droit','1semaine'),
('3','anterieur_gauche','1semaine'),
('4','genoux_droit','1semaine'),
('5','genoux_gauche','1semaine')

insert into [dbo].[Fracture]([dbo].[Fracture].[Id_Fracture], [dbo].[Fracture].[Type_fracture], [dbo].[Fracture].[fracture_indisponibilité])
values
('1','boulet','6mois'),
('2','canon','1an'),
('3','jarret','3mois'),
('4','boulet','6mois');

SET IDENTITY_INSERT [Proprietaire] ON
insert [dbo].[Proprietaire]([dbo].[Proprietaire].[Id_Proprietaire],[dbo].[Proprietaire].[Nom_Proprietaire],[dbo].[Proprietaire].[Effectif],[dbo].[Proprietaire].[Date_Arrivée],[dbo].[Proprietaire].[Dernier_Resultat])
values
('10','nicole','35','2020-12-05','1er'),
('20','papot','20','2020-06-03','1er'),
('30','schule','10','2020-08-04','2eme'),
('40','Delay','5','2020-07-05','np'),
('50','deWaele','1','2020-10-15','np')

INSERT INTO [dbo].[Cheval] ([dbo].[Cheval].[Id_Cheval],[dbo].[Cheval].[Nom_cheval],[dbo].[Cheval].[Pere_cheval],[dbo].[Cheval].[Mere_cheval],
[dbo].[Cheval].[Sortie_provisoire],[dbo].[Cheval].[Raison_Sortie],[dbo].[Cheval].[Id_Proprietaire],[dbo].[Cheval].[Id_Soins],[dbo].[Cheval].[Poids],[dbo].[Cheval].[Race],[dbo].[Cheval].[Alimentation],[dbo].[Cheval].[complement_Alimentation])
VALUES  
('1','dala','dalakhani','zarkava','2020-07-02','repos','1','10','450','PS','3litres','none'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','1','20','450','PS','1litres','warning'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','3','30','450','PS','2litres','none'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','1','40','450','PS','1litres','none'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','1','50','450','PS','2litres','none');

insert into [dbo].[Couse] ([dbo].[Couse].[Id_Courses], [dbo].[Couse].[Hippodrome], [dbo].[Couse].[Date_Courses],[dbo].[Couse].[Distance],[dbo].[Couse].[Corde],[dbo].[Couse].[Discipline],
                    [dbo].[Couse].[Terrain],[dbo].[Couse].[Avis],[dbo].[Couse].[Jockey],[dbo].[Couse].[Poids_De_Course])
Values 
('1','Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('2','Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('3','Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('4','Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('5','Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')


insert [dbo].[Historique] ([dbo].[Historique].[Id_historique],[dbo].[Historique].[Id_Cheval],[dbo].[Historique].[Debourage],[dbo].[Historique].[Pré-entrainement],[dbo].[Historique].[Entraineur_précédent],[dbo].[Historique].[Proprietaire_précédent])
values
('1','2','malenfant','malenfant','dubois','dubuisson'),
('2','4','perceval','perceval','nami','dubuisson'),
('3','3','caradoc','perceval','dubois','leona'),
('4','5','dugarry','marion','leblanc','dubuisson'),
('5','2','malenfant','malenfant','dubois','kartus');



insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],[dbo].[Soins].[Id_Soins],[dbo].[Soins].[Id_Employe],[dbo].[Soins].[Vermifuge],[dbo].[Soins].[Marechal_derniere_visite],[dbo].[Soins].[Note_Libre])
values
('1','10','4','2020-01-25','2020-09-10','complet'),
('1','20','2','2020-04-07','2020-08-11','complet'),
('2','30','2','2020-03-25','2020-07-15','complet'),
('4','40','4','2020-01-15','2020-06-04','complet'),
('3','50','5','2020-06-25','2020-09-10','complet'),
('1','11','5','2020-05-23','2020-05-23','complet'),
('1','12','2','2020-05-23','2020-06-12','complet'),
('1','13','1','2020-05-23','2020-07-11','complet'),
('1','14','3','2020-05-23','2020-08-12','complet'),
('1','15','3','2020-05-23','2020-05-13','complet')





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
ALTER TABLE [dbo].[Soins] WITH CHECK CHECK CONSTRAINT [FK_Soins_ToFracture];

ALTER TABLE [dbo].[Soins] WITH CHECK CHECK CONSTRAINT [FK_Soins_ToInfiltration];

ALTER TABLE [dbo].[Soins] WITH CHECK CHECK CONSTRAINT [FK_Soins_ToTendinite];


GO
PRINT N'Mise à jour terminée.';


GO
