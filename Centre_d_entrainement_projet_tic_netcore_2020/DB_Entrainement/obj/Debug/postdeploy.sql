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

INSERT INTO Cheval (Id_Cheval,Nom_cheval,Pere_cheval,Mere_cheval,
Sortie_provisoire,Raison_Sortie,Id_Proprietaire,Id_Soins,Poids,Race)
VALUES  
('1','dala','dalakhani','zarkava','2020-07-02','repos','1','0','450','PS'),
('2','khani','dalakhani','zarkava','2020-07-12','repos','1','0','450','PS'),
('3','zarkandar','dalakhani','zarkava','2020-11-02','repos','1','0','450','PS'),
('4','dubawi','dalakhani','zarkava','2020-05-02','repos','1','0','450','PS'),
('5','alpha spirit','zarak','zarkava','2020-09-24','repos','1','0','450','PS')

insert into Couse (Id_Courses, Hippodrome, Date_Courses,Distance,Corde,Discipline,
                    Terrain,Avis,Jockey,Poids_De_Course)
Values 
('1','Auteuil','2020-09-01','4600','8','steeple','lourd','pas degueux','gueguen','68'),
('2','Auteuil','2020-09-02','3600','gauche','haie','tres lourd','bien','obrian','68'),
('3','Dieppe','2020-10-03','3800','droite','steeple','bon','bof','zuliani','68'),
('4','Longchamps','2020-09-04','1600','droite','plat','léger','passable','lestrade','68'),
('5','Compiegne','2020-09-05','3900','gauche','steeple','lourd','degueux','masure','68')

insert into Employé (Id_Employé, Nom_Employé, Date_Embauche, Statuts_Employé)
values
('1','Detori','2020-10-04','freelance'),
('1','Detori','2020-10-04','freelance'),
('1','Detori','2020-10-04','freelance'),
('1','Detori','2020-10-04','freelance'),
('1','Detori','2020-10-04','freelance'),

GO
