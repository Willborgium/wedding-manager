CREATE TABLE [dbo].[PaymentMethod]
(
	[Id] INT NOT NULL IDENTITY,
	[Description] NVARCHAR(32) NOT NULL,
	CONSTRAINT [PK_PaymentMethod_Id]
		PRIMARY KEY CLUSTERED ([Id])
)
