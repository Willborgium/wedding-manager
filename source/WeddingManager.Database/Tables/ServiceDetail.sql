CREATE TABLE [dbo].[ServiceDetail]
(
	[Id] INT NOT NULL IDENTITY,
	[ServiceId] INT NOT NULL,
	[DateSuppressed] DATE,
	[Details] NVARCHAR(512),
	[Location] NVARCHAR(512),
	[StartTime] DATETIME NOT NULL,
	[EndTime] DATETIME,
	CONSTRAINT [PK_ServiceDetail_Id]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_ServiceDetail_ServiceId]
		FOREIGN KEY ([ServiceId])
		REFERENCES [dbo].[Service] ([Id])
)
