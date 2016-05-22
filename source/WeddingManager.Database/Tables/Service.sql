CREATE TABLE [dbo].[Service]
(
	[Id] INT NOT NULL IDENTITY,
	[CustomerId] INT NOT NULL,
	[DateSuppressed] DATETIMEOFFSET,
	[Description] NVARCHAR(512),
	CONSTRAINT [PK_Service_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Service_CustomerId]
		FOREIGN KEY ([CustomerId])
		REFERENCES [dbo].[Customer] ([Id])
)
