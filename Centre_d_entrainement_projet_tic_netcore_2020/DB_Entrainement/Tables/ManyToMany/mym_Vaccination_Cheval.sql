CREATE TABLE [dbo].[mym_Vaccination_Cheval]
(
	[Id] INT NOT NULL PRIMARY KEY, 

    [VaccinationId_Vaccination] INT NOT NULL, 
    [ChevalId_Cheval] INT NOT NULL, 
    CONSTRAINT [FK_mym_Vaccination_Cheval_ToVaccination] FOREIGN KEY ([VaccinationId_Vaccination]) REFERENCES [dbo].[Vaccination]([Id_vaccination]), 
    CONSTRAINT [FK_mym_Vaccination_Cheval_ToCheval] FOREIGN KEY ([ChevalId_Cheval]) REFERENCES [dbo].[Cheval]([Id_Cheval])

)
