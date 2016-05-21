CREATE TABLE [dbo].[CustomerInteractionType]
(
	[Id] INT NOT NULL IDENTITY,
	[Description] NVARCHAR(64) NOT NULL,
	CONSTRAINT [PK_CustomerInteractionType_Id]
		PRIMARY KEY CLUSTERED ([Id])
)
