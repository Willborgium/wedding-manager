CREATE TABLE [dbo].[Expense]
(
	[Id] INT NOT NULL IDENTITY,
	[CompanyId] INT NOT NULL,
	[Amount] DECIMAL(8, 2) NOT NULL,
	[CreatedDate] DATE NOT NULL,
	[Description] NVARCHAR(512),
	CONSTRAINT [PK_Expense]
		PRIMARY KEY CLUSTERED ([Id]),
	CONSTRAINT [FK_Expense_CompanyId]
		FOREIGN KEY ([CompanyId])
		REFERENCES [dbo].[Company] ([Id])
)
