CREATE TABLE [dbo].[Service]
(
	[Id] INT NOT NULL IDENTITY,
	[CustomerId] INT NOT NULL,
	[Description] NVARCHAR(512),
	[Location] NVARCHAR(512),
	[StartTime] DATETIME NOT NULL,
	[EndTime] DATETIME,
	CONSTRAINT [PK_Service_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Service_CustomerId]
		FOREIGN KEY ([CustomerId])
		REFERENCES [dbo].[Customer] ([Id])
)
