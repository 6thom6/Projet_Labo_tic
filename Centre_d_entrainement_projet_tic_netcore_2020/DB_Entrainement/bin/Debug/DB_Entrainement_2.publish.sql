/*
Script de déploiement pour DB_Projet_Centre_Entrainement

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_Projet_Centre_Entrainement"
:setvar DefaultFilePrefix "DB_Projet_Centre_Entrainement"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\"

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
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[Cheval]...';


GO
CREATE TABLE [dbo].[Cheval] (
    [Id_Cheval]         INT           NOT NULL,
    [Pere_cheval]       NVARCHAR (50) NOT NULL,
    [Mere_cheval]       NVARCHAR (50) NOT NULL,
    [Sortie_provisoire] NVARCHAR (50) NULL,
    [Raison_Sortie]     NVARCHAR (50) NULL,
    [En_Activité]       BINARY (50)   NOT NULL,
    [Id_Proprietaire]   INT           NOT NULL,
    [Id_Soins]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Cheval] ASC)
);


GO
PRINT N'Création de [dbo].[Course]...';


GO
CREATE TABLE [dbo].[Course] (
    [Id_Courses]   INT            NOT NULL,
    [Hippodrome]   NVARCHAR (50)  NOT NULL,
    [Date_Courses] DATETIME       NOT NULL,
    [Distance]     INT            NOT NULL,
    [Corde]        NVARCHAR (50)  NOT NULL,
    [Discipline]   NVARCHAR (50)  NOT NULL,
    [Terrain]      NVARCHAR (50)  NOT NULL,
    [Avis]         NVARCHAR (MAX) NULL,
    [Jockey]       NVARCHAR (50)  NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id_Courses] ASC)
);


GO
PRINT N'Création de [dbo].[Employé]...';


GO
CREATE TABLE [dbo].[Employé] (
    [Id_Employé]      INT           NOT NULL,
    [Nom_Employé]     NVARCHAR (50) NOT NULL,
    [Date_Embauche]   DATE          NULL,
    [Statuts_Employé] NVARCHAR (50) NOT NULL,
    [SoinsId_Cheval]  INT           NULL,
    [Soinsid_Soins]   INT           NULL,
    PRIMARY KEY CLUSTERED ([Id_Employé] ASC)
);


GO
PRINT N'Création de [dbo].[Entrainement]...';


GO
CREATE TABLE [dbo].[Entrainement] (
    [Id_Entainement] INT           NOT NULL,
    [Cheval]         NVARCHAR (50) NOT NULL,
    [Plat]           NVARCHAR (50) NULL,
    [Obstacle]       NVARCHAR (50) NULL,
    [Marcheur]       NVARCHAR (50) NULL,
    [Durée]          NCHAR (10)    NULL,
    [Pré]            NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_Entainement] ASC)
);


GO
PRINT N'Création de [dbo].[Fracture]...';


GO
CREATE TABLE [dbo].[Fracture] (
    [Type_fracture]            NVARCHAR (50) NOT NULL,
    [fracture_indisponibilité] DATE          NOT NULL,
    [Id_Fracture]              INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_Fracture] ASC)
);


GO
PRINT N'Création de [dbo].[Historique]...';


GO
CREATE TABLE [dbo].[Historique] (
    [Id_historique]          INT           NOT NULL,
    [Id_Cheval]              INT           NULL,
    [Debourage]              NVARCHAR (50) NULL,
    [Pré-entrainement]       NVARCHAR (50) NULL,
    [Entraineur_précédent]   NVARCHAR (50) NULL,
    [Proprietaire_précédent] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id_historique] ASC)
);


GO
PRINT N'Création de [dbo].[Infiltration]...';


GO
CREATE TABLE [dbo].[Infiltration] (
    [Id_Infiltration]                    INT           NOT NULL,
    [Infiltration_Type]                  NVARCHAR (50) NULL,
    [Delai_infiltration_indisponibilité] DATE          NULL,
    PRIMARY KEY CLUSTERED ([Id_Infiltration] ASC)
);


GO
PRINT N'Création de [dbo].[mym_Cheval_Entrainement]...';


GO
CREATE TABLE [dbo].[mym_Cheval_Entrainement] (
    [Id]                              INT NOT NULL,
    [MYM_ChevaliId_Cheval]            INT NULL,
    [MYM_Entrainementid_Entrainement] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[mym_Course_cheval]...';


GO
CREATE TABLE [dbo].[mym_Course_cheval] (
    [Id]               INT NOT NULL,
    [ChevalId_Cheval]  INT NULL,
    [CoursesId_Course] INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[mym_Employé_Entrainement]...';


GO
CREATE TABLE [dbo].[mym_Employé_Entrainement] (
    [Id]                          INT NOT NULL,
    [EmployéID_Employé]           INT NOT NULL,
    [EntrainementID_Entrainement] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[mym_Vaccination_Cheval]...';


GO
CREATE TABLE [dbo].[mym_Vaccination_Cheval] (
    [Id]                        INT NOT NULL,
    [VaccinationId_Vaccination] INT NOT NULL,
    [ChevalId_Cheval]           INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Création de [dbo].[Proprietaire]...';


GO
CREATE TABLE [dbo].[Proprietaire] (
    [Id_Proprietaire]  INT            IDENTITY (1, 1) NOT NULL,
    [Nom]              NVARCHAR (MAX) NULL,
    [Effectif]         INT            NULL,
    [Date_Arrivée]     DATETIME       NULL,
    [Dernier_Resultat] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id_Proprietaire] ASC)
);


GO
PRINT N'Création de [dbo].[Soins]...';


GO
CREATE TABLE [dbo].[Soins] (
    [Id_Soins]                 INT            NOT NULL,
    [Id_Cheval]                INT            NOT NULL,
    [Id_Employe]               INT            NOT NULL,
    [Vermifuge]                DATE           NOT NULL,
    [Marechal_derniere_visite] DATE           NOT NULL,
    [Alimentation]             NVARCHAR (50)  NOT NULL,
    [Complement_Alimentation]  NVARCHAR (50)  NOT NULL,
    [Note_Libre]               NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id_Soins] ASC)
);


GO
PRINT N'Création de [dbo].[Tendinite]...';


GO
CREATE TABLE [dbo].[Tendinite] (
    [Type_tendinite]            INT  NOT NULL,
    [tendinite_Indisponibilité] DATE NOT NULL,
    [Id_Tendinite]              INT  NOT NULL,
    CONSTRAINT [PK_Tendinite] PRIMARY KEY CLUSTERED ([Id_Tendinite] ASC)
);


GO
PRINT N'Création de [dbo].[Vaccination]...';


GO
CREATE TABLE [dbo].[Vaccination] (
    [Id_vaccination]        INT           NOT NULL,
    [Nom_vaccin]            NVARCHAR (50) NOT NULL,
    [Delai_Indisponibilité] DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_vaccination] ASC)
);


GO
PRINT N'Création de [dbo].[FK_Cheval_Proprietaire]...';


GO
ALTER TABLE [dbo].[Cheval]
    ADD CONSTRAINT [FK_Cheval_Proprietaire] FOREIGN KEY ([Id_Proprietaire]) REFERENCES [dbo].[Proprietaire] ([Id_Proprietaire]);


GO
PRINT N'Création de [dbo].[FK_Cheval_Soins]...';


GO
ALTER TABLE [dbo].[Cheval]
    ADD CONSTRAINT [FK_Cheval_Soins] FOREIGN KEY ([Id_Soins]) REFERENCES [dbo].[Soins] ([Id_Soins]);


GO
PRINT N'Création de [dbo].[FK_Fracture_ToSoins]...';


GO
ALTER TABLE [dbo].[Fracture]
    ADD CONSTRAINT [FK_Fracture_ToSoins] FOREIGN KEY ([Id_Fracture]) REFERENCES [dbo].[Soins] ([Id_Soins]);


GO
PRINT N'Création de [dbo].[FK_Historique_ToCheval]...';


GO
ALTER TABLE [dbo].[Historique]
    ADD CONSTRAINT [FK_Historique_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_Infiltration_ToSoins]...';


GO
ALTER TABLE [dbo].[Infiltration]
    ADD CONSTRAINT [FK_Infiltration_ToSoins] FOREIGN KEY ([Id_Infiltration]) REFERENCES [dbo].[Soins] ([Id_Soins]);


GO
PRINT N'Création de [dbo].[FK_mym_Cheval_Entrainement_ToEntrainement]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement]
    ADD CONSTRAINT [FK_mym_Cheval_Entrainement_ToEntrainement] FOREIGN KEY ([MYM_ChevaliId_Cheval]) REFERENCES [dbo].[Entrainement] ([Id_Entainement]);


GO
PRINT N'Création de [dbo].[FK_mym_Cheval_Entrainement_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Cheval_Entrainement]
    ADD CONSTRAINT [FK_mym_Cheval_Entrainement_ToCheval] FOREIGN KEY ([MYM_Entrainementid_Entrainement]) REFERENCES [dbo].[Entrainement] ([Id_Entainement]);


GO
PRINT N'Création de [dbo].[FK_mym_Course_cheval_ToCourses]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval]
    ADD CONSTRAINT [FK_mym_Course_cheval_ToCourses] FOREIGN KEY ([CoursesId_Course]) REFERENCES [dbo].[Course] ([Id_Courses]);


GO
PRINT N'Création de [dbo].[FK_mym_Course_cheval_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Course_cheval]
    ADD CONSTRAINT [FK_mym_Course_cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_mym_Employé_Entrainement_ToEntrainement]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement]
    ADD CONSTRAINT [FK_mym_Employé_Entrainement_ToEntrainement] FOREIGN KEY ([EntrainementID_Entrainement]) REFERENCES [dbo].[Entrainement] ([Id_Entainement]);


GO
PRINT N'Création de [dbo].[FK_mym_Employé_Entrainement_ToEmployé]...';


GO
ALTER TABLE [dbo].[mym_Employé_Entrainement]
    ADD CONSTRAINT [FK_mym_Employé_Entrainement_ToEmployé] FOREIGN KEY ([EmployéID_Employé]) REFERENCES [dbo].[Employé] ([Id_Employé]);


GO
PRINT N'Création de [dbo].[FK_mym_Vaccination_Cheval_ToVaccination]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval]
    ADD CONSTRAINT [FK_mym_Vaccination_Cheval_ToVaccination] FOREIGN KEY ([VaccinationId_Vaccination]) REFERENCES [dbo].[Vaccination] ([Id_vaccination]);


GO
PRINT N'Création de [dbo].[FK_mym_Vaccination_Cheval_ToCheval]...';


GO
ALTER TABLE [dbo].[mym_Vaccination_Cheval]
    ADD CONSTRAINT [FK_mym_Vaccination_Cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToCheval]...';


GO
ALTER TABLE [dbo].[Soins]
    ADD CONSTRAINT [FK_Soins_ToCheval] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval] ([Id_Cheval]);


GO
PRINT N'Création de [dbo].[FK_Soins_ToEmploye]...';


GO
ALTER TABLE [dbo].[Soins]
    ADD CONSTRAINT [FK_Soins_ToEmploye] FOREIGN KEY ([Id_Employe]) REFERENCES [dbo].[Employé] ([Id_Employé]);


GO
PRINT N'Création de [dbo].[FK_Tendinite_ToSoins]...';


GO
ALTER TABLE [dbo].[Tendinite]
    ADD CONSTRAINT [FK_Tendinite_ToSoins] FOREIGN KEY ([Id_Tendinite]) REFERENCES [dbo].[Soins] ([Id_Soins]);


GO
-- Étape de refactorisation pour mettre à jour le serveur cible avec des journaux de transactions déployés

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '731fbd6f-701e-4fb1-a208-776809adaf2d')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('731fbd6f-701e-4fb1-a208-776809adaf2d')

GO

GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
