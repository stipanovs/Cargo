CREATE TABLE [dbo].[CargoSpecification]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[Description] NVARCHAR(100) NOT NULL,
    [Weight] INT,
	[Volume] INT, 
	CONSTRAINT [PK_CargoSpecification] PRIMARY KEY ([Id])
);
