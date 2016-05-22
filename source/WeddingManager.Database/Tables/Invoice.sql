CREATE TABLE [dbo].[Invoice]
(
	[Id] INT NOT NULL IDENTITY,
	[ServiceId] INT NOT NULL,
	[DateSuppressed] DATETIMEOFFSET,
	[Amount] DECIMAL(8, 2) NOT NULL,
	[Description] NVARCHAR(64),
	[CreatedDate] DATETIMEOFFSET NOT NULL,
	[DueDate] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [PK_Invoice_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Invoice_ServiceId]
		FOREIGN KEY ([ServiceId])
		REFERENCES [dbo].[Service] ([Id])
)
