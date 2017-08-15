CREATE TABLE [dbo].[TranportSpecification]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[TransportType] NVARCHAR(50),
    [WeightCapacity] INT,
	[VolumeCapacity] INT, 
	CONSTRAINT [PK_TransportSpecification] PRIMARY KEY ([Id])
	
);
