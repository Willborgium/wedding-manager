IF (SELECT COUNT(1) FROM [dbo].[PaymentMethod]) = 0
	BEGIN
		INSERT INTO [dbo].[PaymentMethod] ([Description]) VALUES
		('Cash'),
		('Check')
	END