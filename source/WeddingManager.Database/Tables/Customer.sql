CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL IDENTITY,
	[CompanyId] INT NOT NULL,
	[FirstName] NVARCHAR(64) NOT NULL,
	[LastName] NVARCHAR(64) NOT NULL,
	[PhoneNumber] NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_Customer]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Customer_CompanyId]
		FOREIGN KEY ([CompanyId])
		REFERENCES [dbo].[Company] ([Id])
)
