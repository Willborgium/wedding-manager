CREATE TABLE [dbo].[CustomerInteraction]
(
	[Id] INT NOT NULL IDENTITY,
	[CustomerId] INT NOT NULL,
	[DateSuppressed] DATETIME,
	[InteractionType] INT NOT NULL,
	[Date] DATETIME NOT NULL,
	[Notes] NVARCHAR(2048),
	CONSTRAINT [PK_CustomerInteraction_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_CustomerInteraction_CustomerId]
		FOREIGN KEY ([CustomerId])
		REFERENCES [dbo].[Customer] ([Id]),
	CONSTRAINT [FK_CustomerInteraction_InteractionType]
		FOREIGN KEY ([InteractionType])
		REFERENCES [dbo].[CustomerInteractionType] ([Id])
)
