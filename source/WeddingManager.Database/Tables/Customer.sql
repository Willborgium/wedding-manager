CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY,
	[CompanyId] INT NOT NULL,
	[DateSuppressed] DATE,
	[FirstName] NVARCHAR(64) NOT NULL,
	[LastName] NVARCHAR(64) NOT NULL,
	[PhoneNumber] NVARCHAR(32) NOT NULL,
	[Notes] NVARCHAR(2048),
	CONSTRAINT [PK_Customer]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Customer_CompanyId]
		FOREIGN KEY ([CompanyId])
		REFERENCES [dbo].[Company] ([Id])
)
