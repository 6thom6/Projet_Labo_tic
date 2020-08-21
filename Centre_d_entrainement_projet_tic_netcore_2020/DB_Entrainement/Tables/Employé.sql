CREATE TABLE [dbo].[Employé]
(
	[Id_Employé] INT NOT NULL PRIMARY KEY, 
    [Nom_Employé] NVARCHAR(50) NOT NULL, 
    [Date_Embauche] DATE NULL, 
    [Statuts_Employé] NVARCHAR(50) NOT NULL, 
    [SoinsId_Cheval] INT NULL, 
    [Soinsid_Soins] INT NULL, 
   


)
