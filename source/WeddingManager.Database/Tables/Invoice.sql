CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL IDENTITY,
	[ServiceId] INT NOT NULL,
	[Amount] DECIMAL(8, 2) NOT NULL,
	[Description] NVARCHAR(64),
	[CreatedDate] DATE NOT NULL,
	[DueDate] DATE NOT NULL,
	CONSTRAINT [PK_Invoice_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Invoice_ServiceId]
		FOREIGN KEY ([ServiceId])
		REFERENCES [dbo].[Service] ([Id])
)
