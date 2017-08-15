CREATE TABLE [dbo].[LocalityPlace]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(70) NOT NULL UNIQUE,
	[CountryId] INT NOT NULL,
	[ClassType] NVARCHAR(70) NOT NULL 

	CONSTRAINT [PK_LocalityPlace2] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [LocalityPlace_CountryId] FOREIGN KEY([CountryId]) REFERENCES 
	[dbo].[Country]([Id]) ON DELETE NO ACTION
);


