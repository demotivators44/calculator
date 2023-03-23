CREATE TABLE [dbo].[Accident]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[Date] DATE NOT NULL,
	[Type] NVARCHAR(20) NULL,
	[ApproximateDamages] INT NULL,

	--CONSTRAINT [PK_Accident] PRIMARY KEY CLUSTERED ([Id]),
)
GO