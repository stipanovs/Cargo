CREATE TABLE [dbo].[Locality]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[LocalyPlaceId] INT NOT NULL,
	[Line1] NVARCHAR(100) NOT NULL,
	
	[Line2] NVARCHAR(100) NULL, 
    [PostCode] NCHAR(10) NULL,
	
    CONSTRAINT [PK_Locality] PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [Locality_LocalyPlaceId] FOREIGN KEY ([LocalyPlaceId]) REFERENCES [dbo].[LocalityPlace]([Id]) ON DELETE NO ACTION,
);
