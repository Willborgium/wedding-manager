CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL IDENTITY,
	[ServiceId] INT NOT NULL,
	[DateSuppressed] DATETIMEOFFSET,
	[Amount] DECIMAL(8, 2) NOT NULL,
	[PaymentMethodId] INT NOT NULL,
	[DateReceived] DATETIMEOFFSET NOT NULL,
	[Notes] NVARCHAR(512),
	CONSTRAINT [PK_Payment_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Payment_ServiceId]
		FOREIGN KEY ([ServiceId])
		REFERENCES [dbo].[Service] ([Id]),
	CONSTRAINT [FK_Payment_PaymentMethodId]
		FOREIGN KEY ([PaymentMethodId])
		REFERENCES [dbo].[PaymentMethod] ([Id])
)
