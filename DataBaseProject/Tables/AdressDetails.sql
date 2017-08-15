CREATE TABLE [dbo].[AddresDetails]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [PostCode] CHAR(10) NOT NULL, 
    [Line1] NVARCHAR(100) NULL, 
    [Line2] NVARCHAR(100) NOT NULL, 
    [LocalityId] INT NOT NULL, 

    CONSTRAINT [AddressDetails_LocalityId] FOREIGN KEY ([LocalityId]) REFERENCES [Locality]([Id])
	ON DELETE NO ACTION
)
