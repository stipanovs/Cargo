﻿CREATE TABLE [dbo].[Country]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) UNIQUE,
	[NumericCode] INT NOT NULL,
	[Alpha2Code] NVARCHAR(2) NOT NULL UNIQUE,
	CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([Id])
);


