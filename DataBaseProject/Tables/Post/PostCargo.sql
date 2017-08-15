CREATE TABLE [dbo].[PostCargo]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[PublicationDate] DATETIME NOT NULL,
	[DateFrom] DATE NOT NULL,
	[DateTo] DATE NOT NULL,
	[LocalityFromId] INT NOT NULL,
	[LocalityToId] INT NOT NULL,
	[Price] MONEY,
	[CargoSpecificationId] INT,
    [AdditionalInformation] NVARCHAR(100),
	CONSTRAINT [PK_PostCargo] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [PostCargoLocalityFromId] FOREIGN KEY ([LocalityFromId])
	REFERENCES [dbo].[Locality]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [PostCargoLocalityToId] FOREIGN KEY ([LocalityToId])
	REFERENCES [dbo].[Locality]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [CargoSpecificationId] FOREIGN KEY ([CargoSpecificationId])
	REFERENCES [dbo].[CargoSpecification]([Id]) ON DELETE NO ACTION,
	CHECK ([Price] > 0.00)
	
);
