CREATE TABLE [dbo].[Course]
(
	[Id_Hippodrome] INT NOT NULL PRIMARY KEY, 
    [Hippodrome] NVARCHAR(50) NOT NULL, 
    [Date_Courses] DATETIME NOT NULL, 
    [Distance] INT NOT NULL, 
    [Corde] NVARCHAR(50) NOT NULL, 
    [Discipline] NVARCHAR(50) NOT NULL, 
    [Terrain] NVARCHAR(50) NOT NULL, 
    [Avis] NVARCHAR(MAX) NULL, 
    [Id_Cheval] INT NOT NULL, 
    CONSTRAINT [FK_Course_ChevalId] FOREIGN KEY ([Id_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval])
)
