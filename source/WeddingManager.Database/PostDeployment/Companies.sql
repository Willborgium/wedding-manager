USE [WeddingManager]
GO

IF (SELECT COUNT(1) FROM [dbo].[Company]) = 0
	BEGIN
		INSERT INTO [dbo].[Company] ([Name]) VALUES
		('Jenna Lynn Photography')
	END