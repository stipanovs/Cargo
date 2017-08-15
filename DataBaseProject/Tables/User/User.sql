CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY(1,1) NOT NULL,
	[OwnershipTypeId] INT NOT NULL,
	[ActivityProfileId] INT NOT NULL, 
    [ContactPersonId] INT NOT NULL,
	[CountryId] INT NOT NULL,
	[LocalityId] INT NOT NULL, 
	[PhoneNumber] NVARCHAR(100), 
	[Email] NVARCHAR(100), 
	[UserRoleId] INT NOT NULL,
	CONSTRAINT [PK_User] PRIMARY KEY([Id]),
	CONSTRAINT [OwnershipTypeId] FOREIGN KEY ([OwnershipTypeId])
	REFERENCES [dbo].[OwnerShipType]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [ActivityProfileId] FOREIGN KEY ([ActivityProfileId])
	REFERENCES [dbo].[ActivityProfile]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [ContactPersonId] FOREIGN KEY ([ContactPersonId])
	REFERENCES [dbo].[Person]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [CountryId] FOREIGN KEY ([CountryId])
	REFERENCES [dbo].[Country]([Id]) ON DELETE NO ACTION,

	CONSTRAINT [LocalityId] FOREIGN KEY ([LocalityId])
	REFERENCES [dbo].[LocalityPlace]([Id]) ON DELETE NO ACTION,
	CONSTRAINT [UserRoleId] FOREIGN KEY ([UserRoleId])
	REFERENCES [dbo].[UserRole]([Id]) ON DELETE NO ACTION

);
