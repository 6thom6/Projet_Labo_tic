CREATE TABLE [dbo].[Tendinite]
(
	[Type_tendinite] INT NOT NULL , 
    [tendinite_Indisponibilité] DATE NOT NULL, 
    [Id_Tendinite] INT NOT NULL, 
    CONSTRAINT [FK_Tendinite_ToSoins] FOREIGN KEY ([Id_Tendinite]) REFERENCES [dbo].[Soins]([Id_Soins]), 
    CONSTRAINT [PK_Tendinite] PRIMARY KEY ([Id_Tendinite])

)
