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

insert into [dbo].[Entrainement] ([dbo].[Entrainement].[Id_Entainement],[dbo].[Entrainement].[Cheval],[dbo].[Entrainement].[Plat],[dbo].[Entrainement].[Obstacle],[dbo].[Entrainement].[Marcheur],[dbo].[Entrainement].[Durée],[dbo].[Entrainement].[Pré])
values 
('1','dala','1000m','2tours','none','2h','none'),
('2','khani','1500m','3tours','none','2h','none'),
('3','zarkandar','2000m','6tours','none','2h30','none'),
('4','dubawi','3500m','2tours','none','2h','none'),
('5','alpha spirit','3000m','none','2h','1h','none')

insert into [dbo].[Course] ([dbo].[Course].[Id_Courses], [dbo].[Couse].[Hippodrome], [dbo].[Couse].[Date_Courses],[dbo].[Couse].[Distance],[dbo].[Couse].[Corde],[dbo].[Couse].[Discipline],
                    [dbo].[Couse].[Terrain],[dbo].[Couse].[Avis],[dbo].[Couse].[Jockey],[dbo].[Couse].[Poids_De_Course])
Values 
('1','Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('2','Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('3','Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('4','Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('5','Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')

insert into [dbo].[Employé] ([dbo].[Employé].[Id_Employé], [dbo].[Employé].[Nom_Employé], [dbo].[Employé].[Date_Embauche], [dbo].[Employé].[Statuts_Employé])
values
('1','zuliani','2020-10-01','jockey'),
('2','Lemagnen','2020-10-02','apprenti'),
('3','Nabet','2020-10-03','garcon_decurie'),
('4','Lestrade','2020-10-04','garcon_de_voyage'),
('5','Gallon','2020-10-05','jockey')


insert [dbo].[Vaccination]([dbo].[Vaccination].[Id_vaccination],[dbo].[Vaccination].[Nom_vaccin],[dbo].[Vaccination].[Delai_Indisponibilité])
values
('1','polyo','2020-10-10'),
('5','polyo','2020-10-12'),
('3','polyo','2020-10-13'),
('4','polyo','2020-10-14'),
('2','polyo','2020-10-15')




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
('1','dala','dalakhani','zarkava','2020-07-02','repos','10','10','450','PS','3litres','none'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','20','20','450','PS','1litres','warning'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','30','30','450','PS','2litres','none'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','10','40','450','PS','1litres','none'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','30','50','450','PS','2litres','none');

insert [dbo].[Soins]([dbo].[Soins].[Id_Cheval],[dbo].[Soins].[Id_Soins],
[dbo].[Soins].[Id_Employe],[dbo].[Soins].[Vermifuge],[dbo].[Soins].[Marechal_derniere_visite],[dbo].[Soins].[Note_Libre],
date_de_soin,Type_de_soin,durrée_indisponibilité)
values
('1','10','4','2020-01-25','2020-09-10','complet','6_mars','infiltration_ant_d','7j'),
('1','20','2','2020-04-07','2020-08-11','complet','8_mai','fracture_ant_g','15mois'),
('2','30','2','2020-03-25','2020-07-15','complet','5_avril','tendinite_pos_d','1mois'),
('4','40','4','2020-01-15','2020-06-04','complet','9_decembre','infiltration_ant_d','12j'),
('3','50','5','2020-06-25','2020-09-10','complet','3_fevrier','fracture_pos_g','1an'),
('1','11','5','2020-05-23','2020-05-23','complet','24_juillet','tendinite_pos_d','12j'),
('1','12','2','2020-05-23','2020-06-12','complet','4_juin','fracture_pos_g',''),
('1','13','1','2020-05-23','2020-07-11','complet','25_septembre','tendinite_Ant_g','1mois'),
('1','14','3','2020-05-23','2020-08-12','complet','14_janvier','infiltration_Pos_d','15j'),
('1','15','3','2020-05-23','2020-05-13','complet','15_octobre','fracture_Anterieur_g','6mois')




insert [dbo].[Historique] ([dbo].[Historique].[Id_historique],[dbo].[Historique].[Id_Cheval],[dbo].[Historique].[Debourage],[dbo].[Historique].[Pré-entrainement],[dbo].[Historique].[Entraineur_précédent],[dbo].[Historique].[Proprietaire_précédent])
values
('1','2','malenfant','malenfant','dubois','dubuisson'),
('2','4','perceval','perceval','nami','dubuisson'),
('3','3','caradoc','perceval','dubois','leona'),
('4','5','dugarry','marion','leblanc','dubuisson'),
('5','2','malenfant','malenfant','dubois','kartus');










GO
